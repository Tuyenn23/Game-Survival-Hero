using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate_1 : UltimateBase
{
    Tweener _Move;
    public override IEnumerator AniEvent()
    {
        throw new System.NotImplementedException();
    }
    private void OnEnable()
    {
        Move();
    }

    public void Move()
    {
        _Move = transform.DOMove(InputManager.ins.getMousePos(), 3f).SetSpeedBased(true);
        _Move.SetLoops(2, LoopType.Yoyo);
        _Move.OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyBase Enemy = collision.GetComponent<EnemyBase>();
        if (Enemy == null) return;

        Enemy.takeDamage(1);
    }

    private void OnDisable()
    {
        _Move.Kill();
    }
}
