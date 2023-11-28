using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ultimate_2 : UltimateBase
{

    private void OnEnable()
    {
        boxCollider2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy)
        {
            enemy.takeDamage(Damage);
        }
    }

    public override IEnumerator AniEvent()
    {
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(timeDestroy);

        Destroy(gameObject);
    }
}
