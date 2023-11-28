using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemSO DataItem;
    public int ID;
    public TypeItem Type;
    public List<ITEMVALUE> general = new List<ITEMVALUE>();

    protected virtual void Start()
    {
        InitValue();
    }
    public void InitValue()
    {
        ITEM item = DataItem.getItemByTypeAndId(Type, ID);
        for (int i = 0; i < item.Values.Count; i++)
        {
            general.Add(item.Values[i]);
        }
    }

    public abstract void Use();
}
