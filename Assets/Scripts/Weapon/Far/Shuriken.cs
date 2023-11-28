using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public class Shuriken : FarBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (CurTime <= 0)
        {
            CanShot();
        }
    }
    protected override void CanShot()
    {
        StartCoroutine(Shot());
        CurTime = TimeShot;
    }
    IEnumerator Shot()
    {
        for (int i = 0; i < Level; i++)
        {
            BulletShuriken bullet = Pooler.Instance.Spawn<BulletShuriken>(PrefabStorage.Instance.bulletShuriken.gameObject, transform.position, Quaternion.identity);
            SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.HitShuriken);
            bullet.Damage = Damage;
            bullet.Dir = (InputManager.ins.getMousePos() - transform.position).normalized;
            yield return Yielders.Get(0.1f);
        }
    }


    public override void Upgrade()
    {
        Level++;
        Damage = Damage + Level;
    }

    public override void initPos()
    {
        transform.localPosition = new Vector3(1, 0, 0);
    }
}
