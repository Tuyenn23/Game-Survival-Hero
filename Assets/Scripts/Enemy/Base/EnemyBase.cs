using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] public EnemyHeal _healbar;
    [SerializeField] protected EnemySO _dataEnemy;
    [SerializeField] public TypeEnemy _type;
    [SerializeField] protected int _Id;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _Maxhp;
    [SerializeField] protected int _damage;

    protected Tweener _move;
    bool isFipRight = false;
    public bool isDead = false;


    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        LookAtPlayer();
    }
    public virtual void InitData()
    {
        ENEMY enemy = _dataEnemy.getEnemyById(_type, _Id);

        float randomSpeed = Random.Range(0.2f, 1);
        _Maxhp = enemy.Health;
        _hp = _Maxhp;
        _healbar.SetBar(_hp, _Maxhp);
        _damage = enemy.Damage;
        _speed = enemy.Speed + randomSpeed;
    }
    protected abstract void Move();

    protected virtual void LookAtPlayer()
    {
        Vector3 fliped = transform.localScale;

        if (PrefabStorage.Instance.Player == null) return;

        if (PrefabStorage.Instance.Player.transform.position.x < transform.position.x && isFipRight)
        {
            transform.localScale = fliped;
            transform.Rotate(0, 180, 0);
            isFipRight = false;
        }
        else if (PrefabStorage.Instance.Player.transform.position.x > transform.position.x && !isFipRight)
        {
            transform.localScale = fliped;
            transform.Rotate(0, 180, 0);
            isFipRight = true;
        }
    }


    public virtual void takeDamage(int damage)
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
            if(_type == TypeEnemy.Boss)
            {
                UiController.instance.HealthBoss.SetActive(false);
                GameManager.ins.waveManager.DelayedEndWave();
            }
            else
            {
                int idItem = Random.Range(0, PrefabStorage.Instance.L_items.Count);
                ItemBase item = Instantiate(PrefabStorage.Instance.L_items[idItem], transform.position, Quaternion.identity);
                item.InitValue();
                GameManager.ins.AmoutEnemyWave++;

                if (GameManager.ins.AmoutEnemyWave == GameManager.ins.waveManager.amoutEnemy)
                {
                    GameManager.ins.waveManager.DelayedEndWave();
                }
            }

            isDead = true;
            _move.Kill();
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        _move.Kill();
    }
}
