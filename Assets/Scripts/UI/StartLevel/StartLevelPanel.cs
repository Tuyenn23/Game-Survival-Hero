using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelPanel : UICanvas
{
    public Button btn_startgame;


    private void Start()
    {
        btn_startgame.onClick.AddListener(StartGame);
        Show(true);
    }
    public void StartGame()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        GameManager.ins.StartLevel();
        HidePanel();
    }
    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);
    }

    public void HidePanel()
    {
        Show(false);
    }
}
