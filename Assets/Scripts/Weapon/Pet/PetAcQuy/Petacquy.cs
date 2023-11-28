using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petacquy : WeaponBase
{
    public override void initPos()
    {
        transform.localPosition = new Vector3(-1, 1, 0);
    }

    public override void Upgrade()
    {
        Level++;
    }
}
