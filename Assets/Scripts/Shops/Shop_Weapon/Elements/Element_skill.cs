using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Element_skill : MonoBehaviour
{
    public ShopWeapon ShopWeapon;
    public ShopWeaponSO DataShop;
    public int Id;
    public TypeWeapon Type;
    public int Rate;
    public TMP_Text Name_skill;
    public Image img_skill;
    public List<Image> stars;
    public Button btn_chooseSkill;

    private void Start()
    {
        btn_chooseSkill.onClick.AddListener(OnchooseSkill);
    }

    public void initData(TypeWeapon _type, int _id)
    {
        Id = _id;
        Type = _type;
        SHOPWEAPON weapon = DataShop.getWeaponByTypeAndId(_type, _id);
        Name_skill.text = weapon.Name;
        img_skill.sprite = weapon.Img;
        Rate = weapon.Rate;
    }

    private void OnchooseSkill()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.WearEquipment);
        if(Type == TypeWeapon.Buff)
        {
            ShopWeapon.passiveBar.initData(Type, Id);
        }

        if(Type != TypeWeapon.Buff && Type != TypeWeapon.Gold && Type != TypeWeapon.Diamond)
        {
            ShopWeapon.activeBar.initData(Type, Id);
        }

        PrefabStorage.Instance.Player.weaponcontroller.WeaponControl(Type, Id);

        Rate++;
        GameManager.ins.Resumed();
        ShopWeapon.Show(false);
    }


}
