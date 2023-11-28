using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponController : SerializedMonoBehaviour
{
    public WeaponSO dataWeapon;

    public Dictionary<TypeWeapon, List<int>> L_weaponOwned = new Dictionary<TypeWeapon, List<int>>();
    public List<WeaponBase> ListWeapon = new List<WeaponBase>();
    public void Weapon(TypeWeapon Type, int id)
    {
        if (Type == TypeWeapon.Buff || Type == TypeWeapon.Gold || Type == TypeWeapon.Diamond) return;

        if (CanUpgrade(Type, id))
        {
            UpgradeWeapon(Type, id);
        }
        else
        {
            WEAPON Dataweapon = dataWeapon.GetWeaponByTypeAndId(Type, id);
            GameObject Weapon = Instantiate(Dataweapon.Prefabs, transform.position, Quaternion.identity);

            WeaponBase wp = Weapon.GetComponent<WeaponBase>();
            wp.InitData();
            ListWeapon.Add(wp);
            Weapon.transform.parent = PrefabStorage.Instance.Player.transform;
            Weapon.transform.localScale = Vector3.one;
            wp.initPos();

            AddWeapon(Type, id);
        }
    }

    public void ResetWeapon()
    {
        foreach (var item in ListWeapon)
        {
            Destroy(item.gameObject);
        }

        L_weaponOwned.Clear();
        ListWeapon.Clear();
    }


    public void Coin(TypeWeapon Type , int id)
    {
        if (Type == TypeWeapon.Gold || Type == TypeWeapon.Diamond)
        {
            WEAPON Dataweapon = dataWeapon.GetWeaponByTypeAndId(Type, id);
            if(Type == TypeWeapon.Gold)
            {
                PlayerDataManager.Instance.AddGold(Dataweapon.Damage);
                UiController.instance.uiMainGameplay._updateCoin?.Invoke();
            }
            else
            {
                PlayerDataManager.Instance.AddDiamond(Dataweapon.Damage);
                UiController.instance.uiMainGameplay._updateCoin?.Invoke();
            }

        }
    }

    public void WeaponControl(TypeWeapon Type , int id)
    {
        switch (Type)
        {
            case TypeWeapon.Near:
                break;
            case TypeWeapon.Far:
                Weapon(Type,id);
                break;
            case TypeWeapon.Pet:
                Weapon(Type, id);
                break;
            case TypeWeapon.Bomb:
                Weapon(Type, id);
                break;
            case TypeWeapon.Buff:
                Buff(Type,id);
                break;
            case TypeWeapon.Gold:
                Coin(Type,id);
                break;
            case TypeWeapon.Diamond:
                Coin(Type, id);
                break;
            default:
                break;
        }

    }

    public void Buff(TypeWeapon Type, int id)
    {
        if(Type == TypeWeapon.Buff)
        {
            WEAPON dataBuff = dataWeapon.GetWeaponByTypeAndId(Type, id);
            PrefabStorage.Instance.Player.AddMaxHeal(dataBuff.Damage);
        }
    }

    public void AddWeapon(TypeWeapon Type, int id)
    {
        if (L_weaponOwned.ContainsKey(Type))
        {
            List<int> L_idOwned = L_weaponOwned[Type];
            L_idOwned.Add(id);

/*            L_weaponOwned.Add(Type, L_idOwned);*/
        }
        else
        {
            List<int> L_id = new List<int>();
            L_id.Add(id);
            L_weaponOwned.Add(Type, L_id);
        }
    }

    public bool CanUpgrade(TypeWeapon Type, int id)
    {
        if (L_weaponOwned.ContainsKey(Type))
        {
            List<int> L_id = L_weaponOwned[Type];

            foreach (var ID in L_id)
            {
                if (ID == id)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public void UpgradeWeapon(TypeWeapon Type, int id)
    {
        if (CanUpgrade(Type, id))
        {
            foreach (var Weapon in ListWeapon)
            {
                if (Weapon.Type == Type && Weapon.ID == id)
                {
                    Weapon.Upgrade();
                }
            }
        }
    }

    /*    public void SpawnBombWeapon(TypeWeapon Type, int id)
        {
            if (Type != TypeWeapon.Bomb) return;

            if (CanUpgrade(Type, id))
            {
                UpgradeWeapon(Type, id);
            }
            else
            {
                WEAPON Dataweapon = dataWeapon.GetWeaponByTypeAndId(Type, id);
                GameObject Weapon = Instantiate(Dataweapon.Prefabs, transform.position, Quaternion.identity);

                Weapon.GetComponent<WeaponBase>();
                Weapon.GetComponent<WeaponBase>().InitData();
                Weapon.transform.parent = PrefabStorage.Instance.Player.transform;
                Weapon.transform.localPosition = new Vector3(0, 0, 0);

                AddWeapon(Type, id);
            }
        }*/

}
