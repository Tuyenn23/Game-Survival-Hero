using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiLobbyController : MonoBehaviour
{
    [Header("Main Ui Lobby")]
    public Button btn_PlayOpenShop;
    public Button btn_setGold;
    public Button btn_clean;

    public Button btn_OpenUiSetting;

    public TMP_Text TextCoin;
    public TMP_Text TextDiaMond;

    [Header("Shop Player")]
    public ShopCharacter ShopCharacter;
    public PopupSetting popupSetting;
    public Button btn_close;
    public RectTransform PanelShop;

    public Action UpdateCore;

    private void OnEnable()
    {
        btn_setGold.onClick.AddListener(Onset);
        btn_clean.onClick.AddListener(OnClean);

        btn_close.onClick.AddListener(Onclose);
        btn_PlayOpenShop.onClick.AddListener(OnOpen);
        btn_OpenUiSetting.onClick.AddListener(OpenUiSetting);
        UpdateCore += initView;
    }

    private void OnClean()
    {
        PlayerDataManager.Instance.DefaultData();
        UpdateCore?.Invoke();
    }

    private void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.instance.SoundData.backgroundMusicsLobby);
        popupSetting.Show(false);
        UpdateCore?.Invoke();
    }

    private void OnDisable()
    {
        UpdateCore -= initView;
        btn_setGold.onClick.RemoveAllListeners();
        btn_close.onClick.RemoveAllListeners();
        btn_PlayOpenShop.onClick.RemoveAllListeners();
        btn_OpenUiSetting.onClick.RemoveAllListeners();
    }

    public void initView()
    {
        TextCoin.text = PlayerDataManager.Instance.GetGold().ToString();
        TextDiaMond.text = PlayerDataManager.Instance.GetDiamond().ToString();
    }

    public void init()
    {
        ShopCharacter.Configure(PlayerDataManager.Instance);
    }

    private void Onset()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        PlayerDataManager.Instance.AddGold(1000);
        PlayerDataManager.Instance.AddDiamond(100);
        UpdateCore?.Invoke();
    }


    private void Onclose()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        PanelShop.gameObject.SetActive(false);
    }

    private void OnOpen()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        PanelShop.gameObject.SetActive(true);
    }

    private void OpenUiSetting()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        popupSetting.Show(true);
    }

}
