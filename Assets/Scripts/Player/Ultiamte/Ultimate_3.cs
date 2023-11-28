using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate_3 : UltimateBase
{
    public override IEnumerator AniEvent()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy == null) return;

        enemy.takeDamage(1);
    }
}
