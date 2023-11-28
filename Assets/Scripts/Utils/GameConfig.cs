
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameConfig : MonoBehaviour
{
    [Header("Chance of Item")]
    [Range(0,100)]
    public float Exp;

    [Range(0, 100)]
    public float Hp;

    [Header("GameRate")]
    public float GameRate;

    [Header("Config Chance Item")]
    public ItemChance itemchance = new ItemChance();




    public float GenerateType(TypeItem TypeItem)
    {
        switch (TypeItem)
        {
            case TypeItem.Exp:
                return Exp;
            case TypeItem.PoiSon:
                return 0;
            case TypeItem.Buff:
                return Hp;
            default:
                return 0;
        }
    }

    private void Start()
    {
        /*CalulateChanceItem(TypeItem.Exp);*/
    }

   /* public void CalulateChanceItem(TypeItem TypeIem)
    {
        float ratio = GenerateType(TypeIem);
        float rate = Random.Range(0f, 1f);

        float RatioRate = ratio / 100;
        Debug.Log(rate);
        Debug.Log(RatioRate);
        if (rate <= RatioRate)
        {
            Debug.Log("Spawn");
        }
    }*/
}

[Serializable]
public class ItemChance
{
    [Range(0, 100)]
    public float Exp;
    [Range(0, 100)]
    public float Hp;
}
