using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public Rigidbody2D rb;
    public int _damage;
    public Vector3 Dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DeSpawnbyTime());
    }

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        rb.velocity = Dir * 20f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (enemy)
        {
            StopAllCoroutines();
            enemy.takeDamage(_damage);
            Pooler.Instance.Despawn(gameObject);
        }
    }

    IEnumerator DeSpawnbyTime()
    {
        yield return Yielders.Get(1f);
        Pooler.Instance.Despawn(gameObject);
    }
}
