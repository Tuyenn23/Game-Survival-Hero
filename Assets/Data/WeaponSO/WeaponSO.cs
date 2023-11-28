using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "Data/Weapon")]
public class WeaponSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MinScrollViewHeight = 200, MaxScrollViewHeight = 400)]
    private Dictionary<TypeWeapon, List<WEAPON>> L_weapon;

    public List<WEAPON> getWeaponsByType(TypeWeapon Type)
    {
        if (!L_weapon.ContainsKey(Type))
        {
            throw new NullReferenceException();
        }

        return L_weapon[Type];
    }

    public WEAPON GetWeaponByTypeAndId(TypeWeapon Type, int id)
    {
        if(L_weapon.ContainsKey(Type))
        {
            List<WEAPON> L_weapons = L_weapon[Type];

            foreach (var weapon in L_weapons)
            {
                if(weapon.ID == id)
                {
                    return weapon;
                }
            }
        }
        return null;
    }
}

public class WEAPON
{
    public int ID;
    public int Damage;
    public int Level;

    public GameObject Prefabs;
}


