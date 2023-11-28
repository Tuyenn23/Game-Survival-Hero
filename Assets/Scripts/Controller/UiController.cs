using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public UiMainGameplay uiMainGameplay;
    public ShopWeapon Shopweapon;
    public StartLevelPanel StartLevelPanel;
    public PanelWin Panelwin;
    public PanelLose panelLose;
    public GameObject panelBoss;
    public GameObject HealthBoss;



    public TMP_Text LevelTxt;


    public event Action GamePaused;
    public event Action GameResumed;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    private void Start()
    {
        initUi();
    }

    public void initUi()
    {
        panelLose.gameObject.SetActive(false);
        Panelwin.gameObject.SetActive(false);
        HealthBoss.SetActive(false);
        StartLevelPanel.Show(true);
    }


    public void Pause()
    {
        Time.timeScale = 0;
        GamePaused?.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameResumed?.Invoke();
    }
}
