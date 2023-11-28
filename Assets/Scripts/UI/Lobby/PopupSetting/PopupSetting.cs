using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupSetting : UICanvas
{
    [Header("Nhac Nen")]
    public Button btn_Nhacnen;
    public TMP_Text txtNhacnenOn;
    public TMP_Text txtNhacnenOff;


    [Header("Rung")]
    public Button btn_Rung;
    public TMP_Text txtRungOn;
    public TMP_Text txtRungOff;

    [Header("Am Thanh")]
    public Button btn_Amthanh;
    public TMP_Text txtAmthanhOn;
    public TMP_Text txtAmthanhOff;

    [Header("Exit & Close")]
    public Button btn_Exit;
    public Button btn_CLose;


    public Sprite ImgOn;
    public Sprite ImgOff;

    private void OnEnable()
    {
        InitAmThanh();
        InitNhacNen();
        btn_Amthanh.onClick.AddListener(toggleFx);
        btn_Nhacnen.onClick.AddListener(toggleMusicbg);
        btn_Exit.onClick.AddListener(OnExit);
        btn_CLose.onClick.AddListener(OnClose);
    }

    private void OnDisable()
    {
        btn_Amthanh.onClick.RemoveAllListeners();
        btn_Nhacnen.onClick.RemoveAllListeners();
        btn_Exit.onClick.RemoveAllListeners();
    }

    public void InitAmThanh()
    {
        bool isOn = PlayerDataManager.Instance.GetMusic();
        btn_Amthanh.image.sprite = isOn ? ImgOn : ImgOff;
        if (isOn)
        {
            txtAmthanhOn.gameObject.SetActive(isOn);
        }
        else
        {
            txtAmthanhOff.gameObject.SetActive(true);
        }
    }

    public void InitNhacNen()
    {
        bool isOn = PlayerDataManager.Instance.GetMusicBg();
        btn_Nhacnen.image.sprite = isOn ? ImgOn : ImgOff;
        if (isOn)
        {
            txtNhacnenOn.gameObject.SetActive(isOn);
        }
        else
        {
            txtNhacnenOff.gameObject.SetActive(true);
        }
    }

    public void toggleFx()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        bool isOn = !PlayerDataManager.Instance.GetMusic();
        btn_Amthanh.image.sprite = isOn ? ImgOn : ImgOff;
        txtAmthanhOn.gameObject.SetActive(isOn);
        txtAmthanhOff.gameObject.SetActive(!isOn);
        PlayerDataManager.Instance.SetMusic(isOn);
        SoundManager.instance.SettingFxSound(isOn);
    }

    public void toggleMusicbg()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        bool isOn = !PlayerDataManager.Instance.GetMusicBg();
        btn_Nhacnen.image.sprite = isOn ? ImgOn : ImgOff;
        txtNhacnenOn.gameObject.SetActive(isOn);
        txtNhacnenOff.gameObject.SetActive(!isOn);
        PlayerDataManager.Instance.SetMusicBg(isOn);
        SoundManager.instance.SettingMusic(isOn);
    }

    private void OnClose()
    {
        Show(false);
    }

    private void OnExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }



}
