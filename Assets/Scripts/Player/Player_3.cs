using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_3 : PlayerBase
{
    public float TimeDestroyUltimate;
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.R) && TimeCountDown <= 0)
        {
            Ultimate();
        }

        if (UltimatePlayer != null)
        {
            TimeDestroyUltimate -= Time.deltaTime;

            if (TimeDestroyUltimate <= 0)
            {
                Destroy(UltimatePlayer.gameObject);
            }
        }
    }
    public override void Ultimate()
    {
        UltimateBase Ultimate3 = Instantiate(PrefabStorage.Instance.fxLua, InputManager.ins.getMousePos(), Quaternion.identity);
        TimeDestroyUltimate = 3;
        UltimatePlayer = Ultimate3;
        TimeCountDown = TimeUlti;
    }
}
