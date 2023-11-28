using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopPlayer", menuName = "Data/ShopPlayer", order = 1)]
public class ShopPlayerSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MinScrollViewHeight = 200, MaxScrollViewHeight = 400)]
    public Dictionary<TypePlayer, List<SHOPPLAYER>> L_PlayerShop;

    public List<SHOPPLAYER> getPlayersbyType(TypePlayer type)
    {
        if (!L_PlayerShop.ContainsKey(type))
        {
            throw new NullReferenceException();
        }
        return L_PlayerShop[type];
    }

    public SHOPPLAYER getPlayerByTypeAndId(TypePlayer type, int id)
    {
        if (L_PlayerShop.ContainsKey(type))
        {
            List<SHOPPLAYER> L_players = L_PlayerShop[type];

            foreach (var player in L_players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }
        }
        return null;
    }
}

public class SHOPPLAYER
{
    public int Id;
    public TypeUnlock TypeUnlock;
    public Sprite Icon;
    public Sprite Model;
    public Sprite img_typeUnlock;
    public Sprite Ultimate;
    public int Price;
}
