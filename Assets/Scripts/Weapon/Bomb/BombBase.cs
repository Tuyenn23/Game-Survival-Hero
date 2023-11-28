using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public abstract class BombBase : WeaponBase
{
    protected override void Start()
    {
        StartCoroutine(Spawn());
    }

    public virtual IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < Level; i++)
            {
                BoomDien boom = Pooler.Instance.Spawn<BoomDien>(PrefabStorage.Instance.Boomdien.gameObject, transform.position, Quaternion.identity);
                boom.Damage = Damage;
                boom.transform.position = transform.position;
                yield return Yielders.Get(0.5f);
            }

            yield return Yielders.Get(5f) ;
        }
    }
}
