using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "Data/ShopWeapon")]
public class ShopWeaponSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MinScrollViewHeight = 200, MaxScrollViewHeight = 400)]
    public Dictionary<TypeWeapon, List<SHOPWEAPON>> L_Weapon;

    public List<SHOPWEAPON> getWeaponByType(TypeWeapon type)
    {
        if (!L_Weapon.ContainsKey(type))
        {
            throw new NullReferenceException();
        }
        return L_Weapon[type];
    }
    public SHOPWEAPON getWeaponByTypeAndId(TypeWeapon Type, int id)
    {
        if (L_Weapon.ContainsKey(Type))
        {
            List<SHOPWEAPON> weapon = L_Weapon[Type];

            foreach (var item in weapon)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
        }
        return null;
    }
}

public class SHOPWEAPON
{
    public int Id;
    public string Name;
    public Sprite Img;
    public int Rate;
}
