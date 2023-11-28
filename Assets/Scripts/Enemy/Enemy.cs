using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{

    protected override void Start()
    {
        base.Start();
        Move();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        if (PrefabStorage.Instance.Player == null) return;

        _move = transform.DOMove(PrefabStorage.Instance.Player.transform.position, _speed).SetEase(Ease.Linear).OnUpdate(() =>
        {
            _move.ChangeEndValue(PrefabStorage.Instance.Player.transform.position, true).SetEase(Ease.Linear);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            player.TakeDamage(_damage);
        }
    }
}
