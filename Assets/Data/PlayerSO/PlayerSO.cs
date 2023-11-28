using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player",menuName ="Data/Player")]
public class PlayerSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MinScrollViewHeight = 200, MaxScrollViewHeight = 400)]
    private Dictionary<TypePlayer, List<PLAYER>> L_dataPlayer;


    public List<PLAYER> getPlayersWithType(TypePlayer _type)
    {
        if(!L_dataPlayer.ContainsKey(_type))
        {
            throw new NullReferenceException();
        }

        return L_dataPlayer[_type];
    }

    public PLAYER getPlayerWithTypeAndID(TypePlayer _type , int id)
    {
        if(L_dataPlayer.ContainsKey(_type))
        {
            List<PLAYER> players = L_dataPlayer[_type];

            foreach (var player in players)
            {
               if(player.ID == id)
                {
                    return player;
                }
            }
        }
        return null;
    }

}
public class PLAYER
{
    public int ID;
    public Sprite Icon;
    public Sprite Ultimate;
    public int Damage;
    public int Health;
    public int Speed;
}
