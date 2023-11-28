using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarBase : WeaponBase
{
    [SerializeField] protected float TimeShot;
    [SerializeField] protected float CurTime;
    protected float timeDelay =0.2f;

    protected override void Start()
    {
        CurTime = TimeShot;
        base.Start();
    }

    protected virtual void Update()
    {
        CurTime -= Time.deltaTime;
    }
    protected abstract void CanShot();
}
