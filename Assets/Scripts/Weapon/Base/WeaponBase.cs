using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponSO DataWeapon;
    [SerializeField] public int ID;
    [SerializeField] public TypeWeapon Type;
    [SerializeField] public int Damage;
    [SerializeField] protected int Level;

    protected virtual void Start()
    {
    }
    public virtual void InitData()
    {
        WEAPON weaponBase = DataWeapon.GetWeaponByTypeAndId(Type, ID);
        Damage = weaponBase.Damage;
        Level = weaponBase.Level;
    }

    public abstract void initPos();
    public abstract void Upgrade();
}
