using System;
using System.Collections;
using System.Collections.Generic;
using Unicorn;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCayanthit : MonoBehaviour
{
    public Rigidbody2D rb;
    public int _damage;

    Coroutine coroutine;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Test();
    }
    public void Move(Vector3 Dir1)
    {
        rb.velocity = Dir1 * 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            player.TakeDamage(_damage);
            Pooler.Instance.Despawn(gameObject);
        }
    }

    public void Test()
    {
        /*        if (coroutine != null)
                    StopCoroutine(coroutine);
                coroutine = */
        StartCoroutine(DeSpawnbyTime());
    }

    IEnumerator DeSpawnbyTime()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Chay den day");
        Pooler.Instance.Despawn(gameObject);
    }
}
