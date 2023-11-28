using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unicorn;
using Unity.VisualScripting;
using UnityEngine;

public class BoomDien : MonoBehaviour
{
    public int Damage;
    public float Range;

    Tweener TweenMove;

    private void Start()
    {
        Move();
    }

    private void Update()
    {
        DestroyAll();
    }

    public void Move()
    {
        Vector3 endPos = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), 0);

        TweenMove = transform.DOMove(endPos, 2f).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy == null) return;

        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.bombNo);
        Attack(Damage);
        TweenMove.Kill();
        GameObject fx = Pooler.Instance.Spawn(PrefabStorage.Instance.FxBombdien, transform.position, Quaternion.identity);
        Pooler.Instance.Despawn(gameObject);
    }


    public void Attack(int damage)
    {
        Collider2D[] ListEnemy = Physics2D.OverlapCircleAll(transform.position, Range);

        if (ListEnemy.Length > 0)
        {
            foreach (Collider2D item in ListEnemy)
            {
                if (item.GetComponent<EnemyBase>())
                    item.GetComponent<EnemyBase>().takeDamage(damage);
            }
        }
    }

    public void DestroyAll()
    { 
        if(GameManager.ins.IsEndGame())
        {
            Pooler.Instance.Despawn(gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
