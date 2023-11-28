using Cinemachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : SerializedMonoBehaviour
{
    private static PrefabStorage instance;

    public static PrefabStorage Instance
    {
        get
        {
            if (instance == null)
            {
                var instances = FindObjectsOfType<PrefabStorage>();
                while (instances.Length > 1)
                {
                    Debug.LogWarning($"There shouldn't be more than one {nameof(PrefabStorage)}!");
                    Destroy(instances[instances.Length - 1]);
                }

                instance = instances[0];
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [Header("Player")]
    public PlayerBase Player;
    public Canvas HpBar;
    public HeathBar HeathBar;
    public ExpBar expBar;

    [Header("Bullet")]
    public BulletShuriken bulletShuriken;
    public BoomDien Boomdien;
    public BulletCayanthit bulletCayanthit;
    public BulletGun bulletGun;
    public BulletBoss bulletBoss;

    [Header("Item")]
    public List<ItemBase> L_items;

    [Header("FX")]
    public UltimateBase Fxtree;
    public UltimateBase fxLua;
    public UltimateBase Fxgio;
    public GameObject FxShuriken;
    public GameObject FxBombdien;
    public GameObject FxSpawnEnemy;
    public GameObject FxChemicals;
    public Skill Skillcaulua;
    public GameObject EndPosCaulua;


    [Header("BG")]
    public GameObject BG;

    [Header("Boss")]
    public EnemyHeal HealthBoss;

    [Header("Cine")]
    public CinemachineVirtualCamera cameraVirtual;
}
