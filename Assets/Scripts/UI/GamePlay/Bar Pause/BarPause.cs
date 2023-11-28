using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarPause : UICanvas
{
    [Header("Top")]
    public Image Icon_player;
    public Image Ultimate_player;

    [Header("Mid")]
    public List<Sprite> Bar_active_cache;
    public List<Image> Bar_active;
    public List<Sprite> Bar_passive_cache;
    public List<Image> Bar_Passive;

    public TMP_Text txt_heath;
    public TMP_Text txt_damage;
    public TMP_Text txt_exp;


    [Header("Bottom")]
    public Button btn_continute;
    public Button btn_vfx;
    public Button btn_music;
    public Button btn_home;

    private void OnEnable()
    {
        InitMusicbg();
        InitVfx();
        InitView();
        InitBar();
        btn_continute.onClick.AddListener(OnContinute);
        btn_home.onClick.AddListener(OnHome);
        btn_vfx.onClick.AddListener(ToggleVfx);
        btn_music.onClick.AddListener(ToggleMusicBg);
    }

    public void InitVfx()
    {
        bool isOn = PlayerDataManager.Instance.GetMusic();
        btn_vfx.image.color = isOn ? Color.white : new Color(0.4245283f, 0.3220007f, 0.3220007f, 1);
    }
    public void ToggleVfx()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        bool isOn = !PlayerDataManager.Instance.GetMusic();
        Debug.Log(isOn);
        btn_vfx.image.color = isOn ? Color.white : new Color(0.4245283f, 0.3220007f, 0.3220007f, 1);
        PlayerDataManager.Instance.SetMusic(isOn);
        SoundManager.instance.SettingFxSound(isOn);
    }
    public void InitMusicbg()
    {
        bool isOn = PlayerDataManager.Instance.GetMusicBg();
        btn_music.image.color = isOn ? Color.white : new Color(0.4245283f, 0.3220007f, 0.3220007f, 1);
    }

    public void ToggleMusicBg()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        bool isOn = !PlayerDataManager.Instance.GetMusicBg();
        Debug.Log(isOn);
        btn_music.image.color = isOn ? Color.white : new Color(0.4245283f, 0.3220007f, 0.3220007f, 1);
        PlayerDataManager.Instance.SetMusicBg(isOn);
        SoundManager.instance.SettingMusic(isOn);
    }

    private void OnDisable()
    {
        btn_continute.onClick.RemoveAllListeners();
        btn_home.onClick.RemoveAllListeners();
        btn_vfx.onClick.RemoveAllListeners();
        btn_music.onClick.RemoveAllListeners();
    }

    public void InitView()
    {
        Icon_player.sprite = PrefabStorage.Instance.Player.Icon;
        Ultimate_player.sprite = UiController.instance.uiMainGameplay.img_Ultimate.sprite;
        txt_heath.text = PrefabStorage.Instance.Player._hp + "/" + PrefabStorage.Instance.Player._maxHp;
        txt_exp.text = PrefabStorage.Instance.Player.CurrentExp + "/" + PrefabStorage.Instance.Player.MaxExp;

        if(PrefabStorage.Instance.Player.GetComponentInChildren<Shuriken>())
        {
            Shuriken bullet = PrefabStorage.Instance.Player.GetComponentInChildren<Shuriken>();
            txt_damage.text = bullet.Damage.ToString();
        }
        else
        {
            txt_damage.text = "Chua So huu Shuriken";
        }
    }

    public void InitBar()
    {
        for (int i = 0; i < Bar_active_cache.Count; i++)
        {
            if (Bar_active.Count < Bar_active_cache.Count) return;

            Bar_active[i].sprite = Bar_active_cache[i];
        }

        for (int i = 0; i < Bar_passive_cache.Count; i++)
        {
            if (Bar_Passive.Count < Bar_passive_cache.Count) return;

            Bar_Passive[i].sprite = Bar_passive_cache[i];
        }
    }

    public void OnContinute()
    {
        GameManager.ins.Resumed();
        Show(false);
    }

    public void OnHome()
    {
        SceneManager.LoadScene(0);

    }

}
