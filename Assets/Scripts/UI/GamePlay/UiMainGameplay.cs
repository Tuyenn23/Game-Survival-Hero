using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiMainGameplay : MonoBehaviour
{
    public Button btn_Ultimate;
    public Button btn_Paused;

    public TMP_Text coin_txt;
    public TMP_Text diamond_txt;
    public TMP_Text CurrentLevel_text;

    public Image img_Ultimate;

    public BarPause barpause;


    public Action _updateCoin;

    private void OnEnable()
    {
        _updateCoin += UpdateCoin;
    }

    private void Start()
    {
        barpause.gameObject.SetActive(false);
        btn_Paused.onClick.AddListener(Paused);
        _updateCoin?.Invoke();
    }
    private void Update()
    {
       UpdateTimeUltimate();
    }

    private void OnDisable()
    {
        _updateCoin -= UpdateCoin;
    }

    public void UpdateTimeUltimate()
    {
        if (PrefabStorage.Instance.Player == null) return;

        if (PrefabStorage.Instance.Player.TimeCountDown <= 0)
        {
            img_Ultimate.color = Color.white;
        }
        else
        {
            img_Ultimate.color = Color.black;
        }
    }

    public void Paused()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        barpause.Show(true);
        GameManager.ins.Paused();
    }

    public void setLeveltxt(int level)
    {
        CurrentLevel_text.text = "Level " + level.ToString();
    }

    public void UpdateCoin()
    {
        coin_txt.text = PlayerDataManager.Instance.GetGold().ToString();
        diamond_txt.text = PlayerDataManager.Instance.GetDiamond().ToString();
    }

}
