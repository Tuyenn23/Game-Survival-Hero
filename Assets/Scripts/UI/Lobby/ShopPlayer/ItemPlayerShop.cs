using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPlayerShop : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public int id;
    [SerializeField] public TypeUnlock TypeUnlock;
    [SerializeField] public TypePlayer TypePlayer;
    [SerializeField] private Image Icon;
    [SerializeField] private Button btn_infor;

    [Header("Data Player and shop")]
    public ShopCharacter shopCharacter;
    public SHOPPLAYER shopPlayer;
    public IDataPlayer dataPlayer;

    private void Start()
    {
        btn_infor.onClick.AddListener(OnInfor);
    }

    /*    public void InitAmThanh(int id)
        {
            this.id = id;
            SHOPPLAYER shopPlayer = dataPlayerSO.getPlayerByTypeAndId(TypePlayer, id);
            Icon.sprite = shopPlayer.Icon;
        }*/


    public void Init(SHOPPLAYER data, ShopCharacter shopCharacter)
    {
        this.shopCharacter = shopCharacter;
        dataPlayer = shopCharacter.dataplayer;
        shopPlayer = data;
        id = data.Id;
        TypeUnlock = data.TypeUnlock;
        Icon.sprite = data.Icon;
    }

    public void OnInfor()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        initChoosePlayer();
        shopCharacter.InitModel(shopPlayer.Model);
        shopCharacter.InitUltimate(shopPlayer.Ultimate);
        shopCharacter.InitPrice(shopPlayer.Price,shopPlayer.img_typeUnlock);
        shopCharacter.initOwned(TypePlayer,id);
    }

    public void initChoosePlayer()
    {
        shopCharacter.SpawnSelected(transform);
        shopCharacter.choosePlayerCloned.idCache = id;
        shopCharacter.choosePlayerCloned.TypePlayerCache = TypePlayer;
        shopCharacter.choosePlayerCloned.TypeUnlockCache = TypeUnlock;

    }
}
