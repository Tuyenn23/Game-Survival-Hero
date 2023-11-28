using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public abstract class BossBase : EnemyBase
{
    [Header("Bullet Hell")]
    public int bulletAmount = 10;
    public float startAngle = 90f, endAngle = 270f;

    public Vector2 BulletMoveDir;



    protected override void Start()
    {
        base.Start();
        StartCoroutine(HellCoroutine());
    }

    protected override void Update()
    {
        LookAtPlayer();
    }

    public IEnumerator HellCoroutine()
    {
        while(isDead == false)
        {
            yield return Yielders.Get(3f);
            BulletHell();
        }
    }

    public void BulletHell()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletDirVt3 = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletDirVt3 - transform.position).normalized;

            BulletBoss bullet = Pooler.Instance.Spawn<BulletBoss>(PrefabStorage.Instance.bulletBoss.gameObject, transform.position, Quaternion.identity);
            bullet._damage = _damage;
            bullet.Move(bulletDir);

            angle += angleStep;

        }
    }

    /*    public virtual void takeDamage(int damage)
        {
            if (isDead) return;
            _hp -= damage;
            _healbar.SetBar(_hp, _Maxhp);
            CheckIsDead();
        }

        public bool CheckIsDead()
        {
            if (_hp <= 0)
            {
                isDead = true;
                Destroy(gameObject);
                return true;
            }
            return false;
        }*/
}
