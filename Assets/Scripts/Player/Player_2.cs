using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : PlayerBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.R) && TimeCountDown <= 0)
        {
            Ultimate();
        }
    }

    public override void Ultimate()
    {
        UltimateBase Ultimate1 = Instantiate(PrefabStorage.Instance.Fxtree, InputManager.ins.getMousePos(), Quaternion.identity);

        UltimatePlayer = Ultimate1;
        TimeCountDown = TimeUlti;
    }
}
