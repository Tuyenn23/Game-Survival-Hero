using System;
using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    [Header("UI")]
    public UiController uiController;

    [Header("Level")]
    public GameFSM GameStateController;
    public LevelManager CurrentLevelManager;
    public LevelResult result;
    public int levelPlaying;

    public PlayerDataManager PlayerDataManager => PlayerDataManager.Instance;
    public bool IsLevelLoading { get; private set; }



    [Header("Wave")]
    public WaveManager waveManager;
    public int AmoutEnemyWave;
    int WaveInLevel;

    public int CurrentWave;

    public event Action PlayerAction;
    public event Action GamePaused;
    public event Action GameResumed;


    [Header("Player")]
    public PlayerState playerState;

    public bool isEndgame;





    private void Awake()
    {
        Debug.Log("Awake");
        if (ins == null)
            ins = this;

        GameStateController = new GameFSM(this);
    }

    private void Start()
    {
        PlayerAction = SetStatePlayer;
        Time.timeScale = 0f;
        InitLevel();
        InitWave();
    }
    public void LoadPlayer()
    {
        if (PrefabStorage.Instance.Player) return;

        int id = PlayerDataManager.GetIdPlayer(TypePlayer.Default);
        PlayerBase Recources = Resources.Load<PlayerBase>(Helper.DataPlayer + id);
        PlayerBase player = Instantiate(Recources, transform.position, Quaternion.identity);
        PrefabStorage.Instance.Player = player;
        PrefabStorage.Instance.cameraVirtual.Follow = player.transform;
        player.Bar = PrefabStorage.Instance.HpBar;
        player.healthBar = PrefabStorage.Instance.HeathBar;
        player.expbar = PrefabStorage.Instance.expBar;
        player.InitData();

        Debug.Log(player);
    }

    public void InitLevel()
    {
        GameStateController.ChangeState(GameState.LOBBY);
        LoadLevel();
    }

    public void LoadLevel()
    {
        CurrentWave = DataLevel1.GetCurrentWave();
        levelPlaying = DataLevel1.GetCurrentLevel();
        LevelController Level = Resources.Load<LevelController>("Level_" + levelPlaying);
        LevelController test = Instantiate(Level, transform.position, Quaternion.identity);
        uiController.uiMainGameplay.setLeveltxt(levelPlaying);
        test.StartLevel();
    }

    public void StartLevel()
    {
        GameStateController.ChangeState(GameState.IN_GAME);
    }
    public void RegisterLevelManager(LevelManager levelManager)
    {
        CurrentLevelManager = levelManager;
        GameStateController.ChangeState(GameState.LOBBY);

        IsLevelLoading = false;
    }

    #region Wave

    public void initWaveManager(WaveManager waveManager)
    {
        this.waveManager = waveManager;
    }
    public void InitWave()
    {
        LoadWave();
    }
    public void LoadWave()
    {
        WaveInLevel = DataLevel1.CountAmoutWaveInResources("LevelNormal/Level_" + levelPlaying);
        GameObject wave = Resources.Load<GameObject>("LevelNormal/Level_" + levelPlaying + "/Wave_" + CurrentWave);

        Debug.Log($"levelPlaying:{levelPlaying} -- WaveInLevel: {WaveInLevel}");
        GameObject Wave_index = Instantiate(wave, transform.position, Quaternion.identity);
    }
    #endregion

    public void playerAction()
    {
        PlayerAction?.Invoke();
    }
    public void SetStatePlayer()
    {
        playerState = PlayerState.Move;
    }


    public void DelayedEndgame(LevelResult result, float delayTime = 0.5f)
    {
        StartCoroutine(DelayedEndgameCoroutine(result, delayTime));
    }

    private IEnumerator DelayedEndgameCoroutine(LevelResult result, float delayTime)
    {
        yield return Yielders.Get(delayTime);
        yield return new WaitForSeconds(delayTime);
        EndLevel(result);
    }

    public void EndLevel(LevelResult levelResult)
    {

        result = levelResult;
        GameStateController.ChangeState(GameState.END_GAME);
        if (levelResult == LevelResult.Win)
        {
            IncreaseLevel(levelPlaying);
        }
    }
    public void increaseWave()
    {
        AmoutEnemyWave = 0;
        IncreaseWave();
        LoadWave();
    }

    public void IncreaseWave()
    {
        if (DataLevel1.GetCurrentWave() == WaveInLevel) return;
        CurrentWave++;
    }

    public void IncreaseLevel(int level)
    {
        int totalLevel = DataLevel1.CountAmoutFolderInResources("Assets/Resources/LevelNormal");
        
        if (DataLevel1.GetCurrentLevel() == totalLevel) return;

        int currentLevel = DataLevel1.GetCurrentLevel();
        level++;
        levelPlaying = level;
        if (level > currentLevel)
        {
            DataLevel1.SetLevel(level);
        }
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        Debug.Log("Pause");
        GamePaused?.Invoke();
    }

    public void Resumed()
    {
        Time.timeScale = 1f;
        GameResumed?.Invoke();
    }

    public bool IsEndGame()
    {
        if (CurrentWave == WaveInLevel)
        {
            return true;
        }
        return false;
    }

    public void NextLevel()
    {
        StartCoroutine(DelayLoadLevel());
    }

    IEnumerator DelayLoadLevel()
    {
        yield return null;
        isEndgame = false;
        CurrentWave = DataLevel1.GetCurrentWave();
        DataLevel1.SetLevel(2);
        ResetDataPlayer();
        InitLevel();
        StartLevel();
        InitWave();
    }


    public void ResetDataPlayer()
    {
        PrefabStorage.Instance.Player.ResetLevel();
        PrefabStorage.Instance.Player.weaponcontroller.ResetWeapon();
    }

    private void Update()
    {
        if (!IsLevelLoading)
            GameStateController.Update();
    }

    private void FixedUpdate()
    {
        if (!IsLevelLoading)
            GameStateController.FixedUpdate();
    }

    private void LateUpdate()
    {
        if (!IsLevelLoading)
            GameStateController.LateUpdate();
    }
}
