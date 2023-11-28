using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1 : PlayerBase
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
        float Distance = Vector3.Distance(transform.position, InputManager.ins.getMousePos());
        if (Distance > 15f) return;

        UltimateBase Ultimate1 = Instantiate(PrefabStorage.Instance.Fxgio, transform.position, Quaternion.identity);
        UltimatePlayer = Ultimate1;
        TimeCountDown = TimeUlti;

    }
}
