using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public BossBase Boss;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.down * 5f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();

        if(player)
        {
            player.TakeDamage(50);
        }
    }
}
