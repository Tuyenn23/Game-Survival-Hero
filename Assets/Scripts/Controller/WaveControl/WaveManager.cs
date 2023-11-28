using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unicorn;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] private float timeDelay;
    [SerializeField] private float timeSpawn;
    [SerializeField] private TypeSpawn TypeSpawn;

    [SerializeField] private List<EnemyBase> L_prefabs;
    [SerializeField] private List<Transform> L_Pos;
    [SerializeField] public List<EnemyBase> L_Enemies;
    [SerializeField] public List<Transform> L_PosSkill;

    [SerializeField] public List<BossBase> L_Boss;
    [SerializeField] public int amoutEnemy;

    private void Update()
    {
        FollowCamera();
    }
    private void Start()
    {
        GameManager.ins.initWaveManager(this);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        if (TypeSpawn == TypeSpawn.Normal)
        {
            yield return Yielders.Get(timeDelay);
            for (int i = 0; i < amoutEnemy; i++)
            {
                int prefab = Random.Range(0, L_prefabs.Count);
                EnemyBase enemy = Instantiate(L_prefabs[prefab], Getpos(), Quaternion.identity);
                enemy.InitData();
                GameObject Fx = Instantiate(PrefabStorage.Instance.FxSpawnEnemy, enemy.transform.position, Quaternion.identity);
                L_Enemies.Add(enemy);
                yield return Yielders.Get(timeSpawn);
            }
        }
        else
        {
            UiController.instance.panelBoss.SetActive(true);
            SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.WarningBoss);
            yield return Yielders.Get(timeDelay);
            UiController.instance.panelBoss.SetActive(false);
            PrefabStorage.Instance.cameraVirtual.m_Lens.OrthographicSize = 15f;
            yield return Yielders.Get(1f);
            BossBase Boss = Instantiate(L_Boss[0], PrefabStorage.Instance.Player.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
            Boss._healbar = PrefabStorage.Instance.HealthBoss;
            Boss.InitData();
            UiController.instance.HealthBoss.SetActive(true);
            /*            yield return Yielders.Get(timeSpawn);*/
        }
    }

    public Vector3 Getpos()
    {
        int randPos = Random.Range(0, L_Pos.Count);

        return L_Pos[randPos].position;
    }

    public void FollowCamera()
    {
        if (PrefabStorage.Instance.Player == null) return;
        transform.position = Vector3.Slerp(transform.position, PrefabStorage.Instance.Player.transform.position, 2f * Time.deltaTime);
    }

    public void DelayedEndWave(float timeDelay = 0.5f)
    {
        StartCoroutine(DelayedWaveCoroutine(timeDelay));
    }

    private IEnumerator DelayedWaveCoroutine(float timeDelay)
    {
        yield return Yielders.Get(timeDelay);
        yield return new WaitForSeconds(timeDelay);
        EndWave();
    }

    public void EndWave()
    {
        if (GameManager.ins.IsEndGame())
        {
            GameManager.ins.isEndgame = true;
            GameManager.ins.uiController.Shopweapon.activeBar.ResetListSkill();
            GameManager.ins.uiController.uiMainGameplay.barpause.Bar_active_cache.Clear();
            GameManager.ins.uiController.uiMainGameplay.barpause.Bar_passive_cache.Clear();
            GameManager.ins.uiController.Shopweapon.passiveBar.ResetListSkill();
            GameManager.ins.CurrentLevelManager.EndGame(LevelResult.Win);
            Destroy(gameObject);
            Destroy(GameManager.ins.CurrentLevelManager.gameObject);
        }
        else
        {
            SoundManager.instance.StopPlayMusic();
            GameManager.ins.increaseWave();
            Destroy(gameObject);
        }
    }

    public Vector3 getPos()
    {
        int rand = Random.Range(0, L_Pos.Count);

        return L_Pos[rand].position;
    }
}
