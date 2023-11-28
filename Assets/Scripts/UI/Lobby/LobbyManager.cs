using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager ins;
    public UiLobbyController uiLobbyController;


    private void Awake()
    {
        if (ins == null)
            ins = this;
    }
    private void Start()
    {
        uiLobbyController.init();
    }
}
