using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : FarBase
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
    public override void Upgrade()
    {
        Level++;
        TimeShot = TimeShot / Level;
    }

    protected override void CanShot()
    {
        BulletGun bullet = Pooler.Instance.Spawn<BulletGun>(PrefabStorage.Instance.bulletGun.gameObject, transform.position, Quaternion.identity);
        bullet._damage = Damage;
        bullet.Dir = (InputManager.ins.getMousePos() - transform.position).normalized;
        CurTime = TimeShot;
    }

    public override void initPos()
    {
        transform.localPosition = new Vector3(0.53f, -0.33f, 0);
    }
}
