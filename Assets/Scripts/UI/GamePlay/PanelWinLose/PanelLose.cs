using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelLose : UICanvas
{
    public Button btn_exit;
    public Button btn_replay;

    private void OnEnable()
    {
        btn_exit.onClick.AddListener(OnExit);
        btn_replay.onClick.AddListener(OnReplay);

    }

    private void OnReplay()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        SceneManager.LoadScene(1);
    }

    private void OnExit()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        SceneManager.LoadScene(0);
    }
}
