using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="item",menuName ="Data/Item1",order =1)]
public class ItemSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MinScrollViewHeight = 200, MaxScrollViewHeight = 400)]

    private Dictionary<TypeItem, List<ITEM>> DataItem;

    public List<ITEM> getItembyType(TypeItem Type)
    {
        if(!DataItem.ContainsKey(Type))
        {
            throw new NullReferenceException();
        }

        return DataItem[Type];
    }

    public ITEM getItemByTypeAndId(TypeItem Type , int id)
    {
        if (DataItem.ContainsKey(Type))
        {
            List<ITEM> items = DataItem[Type];
            foreach (var item in items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }
        }
        return null;
    }
}
public class ITEM
{
    public int ID;
    public List<ITEMVALUE> Values;
}

public class ITEMVALUE
{
    public int value;
}