using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_active : MonoBehaviour
{
    public Sprite spriteDefault;
    public Dictionary<TypeWeapon, List<int>> L_SkillActiveOwned = new Dictionary<TypeWeapon, List<int>>();
    public List<Image> L_skills;
    public ShopWeapon ShopWeapon;
    public int curItem = 0;

    public void initData(TypeWeapon type, int id)
    {
        if (curItem >= 5 || checkSkillOwned(type, id)) return;
        addDic(type, id);
        L_skills[curItem].color = Color.white;
        L_skills[curItem].sprite = ShopWeapon.DataShop.getWeaponByTypeAndId(type, id).Img;
         
        UiController.instance.uiMainGameplay.barpause.Bar_active_cache.Add(ShopWeapon.DataShop.getWeaponByTypeAndId(type, id).Img);
        curItem++;
    }
    public void addDic(TypeWeapon type , int id)
    {
        if (L_SkillActiveOwned.ContainsKey(type))
        {
            List<int> L_id = L_SkillActiveOwned[type];
            L_id.Add(id);
            L_SkillActiveOwned[type] = L_id;
        }
        else
        {
            List<int> l_id = new List<int>();
            l_id.Add(id);
            L_SkillActiveOwned.Add(type, l_id);
        }
    }

    public bool checkSkillOwned(TypeWeapon type, int id)
    {
        if (L_SkillActiveOwned.ContainsKey(type))
        {
            List<int> L_id = L_SkillActiveOwned[type];

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
            L_skills[i].sprite = spriteDefault;
            L_skills[i].color = Color.white; 
        }

        L_SkillActiveOwned.Clear();
    }
}
