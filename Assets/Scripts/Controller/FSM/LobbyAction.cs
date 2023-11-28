using Common.FSM;
using UnityEngine;

namespace Unicorn.FSM
{
    public class LobbyAction : UnicornFSMAction
    {
        public LobbyAction(GameManager gameManager, FSMState owner) : base(gameManager, owner)
        {
        }

        public override void OnEnter()
        {


            base.OnEnter();
            GameManager.LoadPlayer();
/*            GameManager.UiController.UiMainLobby.Show(true);
            SoundManager.Instance.PlayFxSound(soundEnum: SoundManager.GameSound.Lobby);*/
        }

        public override void OnExit()
        {
            base.OnExit();

            Debug.Log("Tat Ui Main Lobby");
/*            GameManager.UiController.UiMainLobby.Show(false);
            SoundManager.Instance.StopSound(SoundManager.GameSound.Lobby);*/
        }


    }
}