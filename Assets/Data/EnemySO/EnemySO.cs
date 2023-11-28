using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy", order = 1)]
public class EnemySO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels =true,DrawScrollView =true,MaxScrollViewHeight = 400,MinScrollViewHeight =200)]
    private Dictionary<TypeEnemy,List<ENEMY>> L_dataEnemy = new Dictionary<TypeEnemy, List<ENEMY>>();

    public List<ENEMY> getEnemiesByType(TypeEnemy _type)
    {
        if(!L_dataEnemy.ContainsKey(_type))
        {
            throw new NullReferenceException();
        }
        return L_dataEnemy[_type];
    }

    public ENEMY getEnemyById(TypeEnemy _type, int id)
    {
        if(L_dataEnemy.ContainsKey(_type))
        {
           List<ENEMY> L_Enemies = L_dataEnemy[_type];
            foreach(ENEMY enemy in L_Enemies)
            {
                if(enemy.Id == id)
                {
                    return enemy;
                }
            }
        }
        return null;
    }
}

public class ENEMY
{
    public int Id;
    public TypeEnemy Type;
    public int Damage;
    public int Health;
    public int Speed;
}
