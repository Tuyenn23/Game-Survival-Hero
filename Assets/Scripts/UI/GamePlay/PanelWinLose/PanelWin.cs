using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelWin : UICanvas
{
    public Button btn_exit;
    public Button btn_nextlevel;

    private void OnEnable()
    {
        btn_exit.onClick.AddListener(OnExit);
        btn_nextlevel.onClick.AddListener(OnNextLevel);
    }

    private void OnNextLevel()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        gameObject.SetActive(false);
        GameManager.ins.NextLevel();
        /*GameManager.ins.increaseLevel();*/
    }

    private void OnExit()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        SceneManager.LoadScene(0);
    }
}
