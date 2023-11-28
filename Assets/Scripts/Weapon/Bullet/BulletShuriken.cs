using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unicorn;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShuriken : MonoBehaviour
{
    public Rigidbody2D rb;
    public int Damage;
    public Vector3 Dir;


    private void Start()
    {
        StartCoroutine(DespawnBulletDontTrigger());
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        rb.velocity = Dir * 30f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();

        if (enemy == null) return;

        StopCoroutine(DespawnBulletDontTrigger());
        if (enemy._type == TypeEnemy.Boss)
        {
            SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.HitBoss);
        }
        enemy.takeDamage(Damage);
        Pooler.Instance.Despawn(gameObject);
    }


    IEnumerator DespawnBulletDontTrigger()
    {
        yield return Yielders.Get(1.5f);

        Pooler.Instance.Despawn(gameObject);
    }
}
