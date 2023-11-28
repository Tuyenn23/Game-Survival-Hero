using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public int _damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DespawnByTime());
    }

    private void Update()
    {
        DestroyAll();
    }

    public void Move(Vector3 Dir1)
    {
        rb.velocity = Dir1 * 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            StopAllCoroutines();
            player.TakeDamage(_damage);
            Pooler.Instance.Despawn(gameObject);
        }
    }

    IEnumerator DespawnByTime()
    {
        yield return Yielders.Get(5f);
        Pooler.Instance.Despawn(gameObject);
    }

    public void DestroyAll()
    {
        if(GameManager.ins.isEndgame == true)
        {
            Pooler.Instance.Despawn(gameObject);
        }
    }
}
