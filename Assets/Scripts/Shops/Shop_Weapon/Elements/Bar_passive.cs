using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_passive : MonoBehaviour
{
    public Sprite SpriteDefault;
    public Dictionary<TypeWeapon, List<int>> L_SkillPassiveOwned = new Dictionary<TypeWeapon, List<int>>();
    public List<Image> L_skills;
    public ShopWeapon ShopWeapon;
    public int curItem = 5;

    public void initData(TypeWeapon type, int id)
    {
        if (curItem < 0 || checkSkillOwned(type, id)) return;
        addDic(type, id);
        L_skills[curItem].color = Color.white;
        L_skills[curItem].sprite = ShopWeapon.DataShop.getWeaponByTypeAndId(type, id).Img;
        UiController.instance.uiMainGameplay.barpause.Bar_passive_cache.Add(ShopWeapon.DataShop.getWeaponByTypeAndId(type, id).Img);

        curItem--;
    }
    public void addDic(TypeWeapon type, int id)
    {
        if (L_SkillPassiveOwned.ContainsKey(type))
        {
            List<int> L_id = L_SkillPassiveOwned[type];
            L_id.Add(id);
            L_SkillPassiveOwned[type] = L_id;
        }
        else
        {
            List<int> l_id = new List<int>();
            l_id.Add(id);
            L_SkillPassiveOwned.Add(type, l_id);
        }
    }

    public bool checkSkillOwned(TypeWeapon type, int id)
    {
        if (L_SkillPassiveOwned.ContainsKey(type))
        {
            List<int> L_id = L_SkillPassiveOwned[type];

            foreach (var _id in L_id)
            {
                if (_id == id)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ResetListSkill()
    {
        curItem = 0;
        for (int i = 0; i < L_skills.Count; i++)
        {
            L_skills[i].sprite = SpriteDefault;
            L_skills[i].color = Color.white;
        }

        L_SkillPassiveOwned.Clear();
    }
}
