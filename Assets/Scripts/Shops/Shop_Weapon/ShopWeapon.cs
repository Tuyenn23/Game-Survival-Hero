using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ShopWeapon : UICanvas
{
    public Element_skill[] Skills;

    public Button btn_switch;

    public ShopWeaponSO DataShop;
    public Bar_active activeBar;
    public Bar_passive passiveBar;
    public Dictionary<TypeWeapon, List<SHOPWEAPON>> Weapons;
    public Dictionary<TypeWeapon, int> L_Final = new Dictionary<TypeWeapon, int>();



    private void OnValidate()
    {
        if (Skills == null || Skills.Length == 0)
        {
            Skills = transform.GetComponentsInChildren<Element_skill>();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        ShuffleWeapon();
    }

    private void Start()
    {
        GameManager.ins.Paused();
        btn_switch.onClick.AddListener(ShuffleWeapon);
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);
    }

    public void ShuffleWeapon()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.ClickButton);
        Random RandTypeWeapon = new Random();
        var shuffledKey = DataShop.L_Weapon.OrderBy(x => RandTypeWeapon.Next());

        Random randValue = new Random();
        Weapons = shuffledKey.ToDictionary(x => x.Key,
            x => x.Value.OrderBy(x => randValue.Next()).ToList()
            );

        var Skill_3 = Weapons.Take(3);
        foreach (var weapon in Skill_3)
        {
            foreach (var value in weapon.Value)
            {
                if (L_Final.ContainsKey(weapon.Key))
                {
                    L_Final[weapon.Key] = value.Id;
                }
                else
                {
                    L_Final.Add(weapon.Key, value.Id);
                }
            }
        }
        initData();
    }

    public void initData()
    {
        int i = 0;
        foreach (var skill in L_Final)
        {
            if (i >= 3) return;
            Skills[i].initData(skill.Key, skill.Value);
            i++;
        }

        L_Final.Clear();
    }
}
