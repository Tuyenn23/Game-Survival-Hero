using Common.FSM;
/*using Unicorn.Utilities;*/
using UnityEngine;
using System.Collections;


public class EndgameAction : UnicornFSMAction
{
    public EndgameAction(GameManager gameManager, FSMState owner) : base(gameManager, owner)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        /*            SoundManager.Instance.StopFootStep();*/


        ProcessWinLose();

        /*            SoundManager.Instance.PlayFxSound(GameManager.CurrentLevelManager.Result);*/
    }

    private void ProcessWinLose()
    {
        GameManager.ins.Paused();
        switch (GameManager.ins.result)
        {
            case LevelResult.Win:
                SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.GameWin);
                UiController.instance.Panelwin.Show(true);
                break;
            case LevelResult.Lose:
                SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.GameOver);
                UiController.instance.panelLose.Show(true);
                break;
            default:
                break;
        }

        GameManager.ins.StartCoroutine(IEShowInter());
    }

    private IEnumerator IEShowInter()
    {
        yield return new WaitForSeconds(0.4f);

        switch (GameManager.ins.result)
        {
            case LevelResult.Win:
                Debug.Log("Win 1");
                /*                    UnicornAdManager.ShowInterstitial(Helper.inter_end_game_win);*/
                break;
            case LevelResult.Lose:
                Debug.Log("Lose 1");
                /*                    UnicornAdManager.ShowInterstitial(Helper.inter_end_game_lose);*/
                break;
            default:
                break;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        /*            SoundManager.Instance.StopSound(GameManager.CurrentLevelManager.Result);
                    PrefabStorage.Instance.fxWinPrefab.SetActive(false);*/
    }
}