using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : ItemBase
{
    public override void Use()
    {
        PrefabStorage.Instance.Player.AddHealth(general[0].value);
    }
}
