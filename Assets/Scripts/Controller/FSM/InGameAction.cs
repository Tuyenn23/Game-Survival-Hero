using Common.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unicorn.FSM
{
    public class InGameAction : UnicornFSMAction
    {
        public InGameAction(GameManager gameManager, FSMState owner) : base(gameManager, owner)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter Ingame");
            base.OnEnter();
            SoundManager.instance.PlayBGM(SoundManager.instance.SoundData.backgroundMusicsIngame);
            GameManager.playerAction();
            UiController.instance.Shopweapon.Show(true);
/*            Time.timeScale = 1f;*/
            Debug.Log("Start Level");
/*            CurrentLevelManager.Instance.StartLevel();*/
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("Exit In game");
/*            SoundManager.Instance.StopSound(SoundManager.GameSound.BGM);*/
        }
    }
}