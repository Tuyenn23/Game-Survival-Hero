using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv1 : BossBase
{
    protected override void Start()
    {
        base.Start();
        Move();
    }
    protected override void Move()
    {
        if (PrefabStorage.Instance.Player != null)
        {
            _move = transform.DOMove(PrefabStorage.Instance.Player.transform.position + new Vector3(0, 10, 0), 4f).SetLoops(1, LoopType.Yoyo).OnUpdate(() =>
            {
                _move.ChangeEndValue(PrefabStorage.Instance.Player.transform.position + new Vector3(0, 10, 0), true);
            });
        }
    }
}
