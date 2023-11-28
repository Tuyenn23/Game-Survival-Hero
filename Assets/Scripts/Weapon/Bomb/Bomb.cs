using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : BombBase
{
    public override void initPos()
    {
        transform.localPosition = Vector3.zero;
    }

    public override void Upgrade()
    {
        Level++;
        Damage = Damage * Level;
    }
}
