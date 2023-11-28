using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFar : EnemyBase
{
    public float TimeShot;
    public float CurrentTime;

    protected override void Start()
    {
        base.Start();
        CurrentTime = TimeShot;
    }
    protected override void Update()
    {
        base.Update();
        CurrentTime -= Time.deltaTime;
        Move();
    }

    public void Attack()
    { 
        if (CurrentTime <= 0)
        {
            Vector3 PlayerPos = PrefabStorage.Instance.Player.transform.position - transform.position;
            BulletCayanthit bullet = Pooler.Instance.Spawn<BulletCayanthit>(PrefabStorage.Instance.bulletCayanthit.gameObject, transform.position, Quaternion.identity);
            bullet._damage = _damage;
            SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.HitShuriken);
            bullet.Move(PlayerPos);

            CurrentTime = TimeShot;
        }
    }

    protected override void Move()
    {
        if (PrefabStorage.Instance.Player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, PrefabStorage.Instance.Player.transform.position, _speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, PrefabStorage.Instance.Player.transform.position) <= 8f)
        {
            _speed = 0;
            Attack();
        }
        else
        {
            _speed = 2;
        }
    }
}
