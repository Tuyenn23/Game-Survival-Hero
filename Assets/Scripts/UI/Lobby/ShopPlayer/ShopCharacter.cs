using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class ShopCharacter : UICanvas
{
    [Header("Item")]
    public ItemPlayerShop ItemPlayerPrefab;
    public ShopPlayerSO datashop;
    public ChoosePlayer choosePlayerPrefab;
    public ChoosePlayer choosePlayerCloned;

    public TypePlayer TypePlayer;
    public int ID;
    public TypeUnlock TypeUnlock;
    public List<ItemPlayerShop> elements;

    [Header("Data Player")]
    public IDataPlayer dataplayer;

    [Header("UI")]

    public Image img_Model;
    public Image img_Ultimate;

    public Button btn_Play;

    [Header("Button Purchase")]
    public Button btn_Purchase;
    public Image img_Coin;
    public TMP_Text PriceTxt;

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        btn_Purchase.onClick.AddListener(Onpurchase);
        btn_Play.onClick.AddListener(OnPlayGame);
        initData(datashop.getPlayersbyType(TypePlayer));
    }

    public void Configure(IDataPlayer dataplayer)
    {
        this.dataplayer = dataplayer;
    }

    public void CreateItems(int itemCount)
    {
        if (elements.Count >= itemCount)
            return;

        for (int i = 0; i < itemCount; i++)
        {
            var itemPlayer = Instantiate(ItemPlayerPrefab, transform);
            elements.Add(itemPlayer);
        }
    }

    public void initData(List<SHOPPLAYER> shopPlayers)
    {
        CreateItems(shopPlayers.Count);

        for (int i = 0; i < shopPlayers.Count; i++)
        {
            elements[i].Init(shopPlayers[i], this);
        }
    }

    public void InitModel(Sprite Icon)
    {
        img_Model.sprite = Icon;
    }

    public void InitUltimate(Sprite Ultimate)
    {
        img_Ultimate.sprite = Ultimate;
    }

    public void InitPrice(int Price,Sprite img_coin)
    {
        img_Coin.sprite = img_coin;
        PriceTxt.text = Price.ToString();
    }

    public void initOwned(TypePlayer type , int id)
    {
        if (PlayerDataManager.Instance.getUnlockSkin(type, id))
        {
            PriceTxt.text = "Owned";
            btn_Play.gameObject.SetActive(true);
        }
        else
        {
            btn_Play.gameObject.SetActive(false);
        }
    }
    public void SpawnSelected(Transform parent)
    {
        if (choosePlayerCloned == null)
        {
            ChoosePlayer choosePlayerClone = Instantiate(choosePlayerPrefab, transform);
            choosePlayerCloned = choosePlayerClone;
        }
        choosePlayerCloned.transform.SetParent(parent);
        choosePlayerCloned.transform.localPosition = Vector3.zero;
        choosePlayerCloned.transform.localScale = Vector3.one;
    }

    private void Onpurchase()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        TypePlayer = choosePlayerCloned.TypePlayerCache;
        ID = choosePlayerCloned.idCache;
        TypeUnlock = choosePlayerCloned.TypeUnlockCache;
        SHOPPLAYER data = datashop.getPlayerByTypeAndId(TypePlayer, ID);
        if (PlayerDataManager.Instance.getCoinByType(TypeUnlock) < data.Price || PlayerDataManager.Instance.getUnlockSkin(TypePlayer,ID))
        {
            return;
        }
        PlayerDataManager.Instance.setUnlockSkin(TypePlayer, ID);
        PlayerDataManager.Instance.AddCoinByType(TypeUnlock, -data.Price);
        LobbyManager.ins.uiLobbyController.UpdateCore?.Invoke();
        initOwned(TypePlayer, ID);
    }

    private void OnPlayGame()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        TypePlayer = choosePlayerCloned.TypePlayerCache;
        ID = choosePlayerCloned.idCache;
        PlayerDataManager.Instance.SetIdEquipPlayer(TypePlayer, ID);
        SceneManager.LoadScene(1);
    }
}
