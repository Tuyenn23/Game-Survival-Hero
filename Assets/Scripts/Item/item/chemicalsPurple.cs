using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public class chemicalsPurple : ItemBase
{
    protected override void Start()
    {
        base.Start();
    }
    public override void Use()
    {
        PrefabStorage.Instance.Player.TakeDamage(general[0].value);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if(player)
        {
            Use();
        }
    }
}
