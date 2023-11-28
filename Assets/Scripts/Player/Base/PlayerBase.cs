using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class PlayerBase : MonoBehaviour 
{
    [Header("Data Player")]
    [SerializeField] protected PlayerSO DataPlayer;
    [SerializeField] protected int Id;
    [SerializeField] protected TypePlayer _type;
    public Sprite Icon;
    /*    [SerializeField] protected int _damage;*/
    [SerializeField] public int _hp;
    [SerializeField] public int _maxHp;
    [SerializeField] protected int _speed;
    [SerializeField] public Vector3 Dir;
    [Header("Health Bar")]
    [SerializeField] public HeathBar healthBar;
    [SerializeField] public Canvas Bar;

    [Header("Level And Exp")]
    [SerializeField] protected int Level = 1;
    [SerializeField] public int MaxExp = 100;
    [SerializeField] public int CurrentExp;
    [SerializeField] public ExpBar expbar;


    [Header("Player")]
    [SerializeField] protected bool isFlipleft;
    [SerializeField] protected bool isDead;
    [SerializeField] protected PlayerState playerState;

    [Header("Item")]
    public Stack<ItemBase> Items;
    public event Action PickedUpItem;

    [Header("Weapon")]
    public WeaponController weaponcontroller;

    [Header("Ultimate")]
    public UltimateBase UltimatePlayer;
    public float TimeCountDown;
    public float TimeUlti;


    protected virtual void Start()
    {
        Debug.Log("Start");
        UiController.instance.LevelTxt.text = Level.ToString();
        expbar.SetBar(CurrentExp, MaxExp);
        TimeCountDown = TimeUlti;
        weaponcontroller = GetComponent<WeaponController>();
        InitData();
        CurrentExp = 0;
    }

    protected virtual void Update()
    {
        TimeCountDown -= Time.deltaTime;
        playerState = GameManager.ins.playerState;
        LookAtPlayer();
    }

    protected virtual void FixedUpdate()
    {
        if (playerState == PlayerState.Move)
        {
            Move();
        }
    }

    public virtual void InitData()
    {
        PLAYER player = DataPlayer.getPlayerWithTypeAndID(_type, Id);
        /*        _damage = Player.Damage;*/
        _maxHp = player.Health;
        _hp = _maxHp;
        healthBar.SetBar(_hp, _maxHp);
        _speed = player.Speed;
        Icon = player.Icon;

        UiController.instance.uiMainGameplay.img_Ultimate.sprite = player.Ultimate;

    }

    protected virtual void Move()
    {
        if (isDead) return;
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        Dir = new Vector3(xDir, yDir, 0).normalized;
        transform.position += Dir * _speed * Time.deltaTime;

        PlayerFlip();
        /*        Rotate();*/
    }
    public virtual void PlayerFlip()
    {
        {
            Vector3 fliped = transform.localScale;


            if (Dir.x < 0 && !isFlipleft)
            {
                transform.localScale = fliped;
                transform.Rotate(0, 180, 0);
                isFlipleft = true;
            }
            else if (Dir.x > 0 && isFlipleft)
            {
                transform.localScale = fliped;
                transform.Rotate(0, 180, 0);
                isFlipleft = false;
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        if (isDead) return;
        _hp -= damage;
        healthBar.SetBar(_hp, _maxHp);
        if (_hp <= 0)
        {
            GameManager.ins.EndLevel(LevelResult.Lose);
            _hp = 0;
            healthBar.SetBar(_hp, _maxHp);
            isDead = true;
        }

    }

    public virtual void AddHealth(int health)
    {
        if (isDead) return;
        _hp += health;
        healthBar.SetBar(_hp, _maxHp);
        if (_hp >= _maxHp)
        {
            _hp = _maxHp;
            healthBar.SetBar(_hp, _maxHp);
        }

    }

    public virtual void AddMaxHeal(int Amout)
    {
        if (isDead) return;

        _maxHp += Amout;
        healthBar.SetBar(_hp, _maxHp);
    }


    public virtual void LookAtPlayer()
    {
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y - 3, 0);
        Bar.transform.position = Vector3.Slerp(Bar.transform.position, newpos, 1f);
    }

    public void LevelUp()
    {
        GameManager.ins.Paused();
        CurrentExp = 0;
        MaxExp = MaxExp + MaxExp * (Level / 2);
        expbar.SetBar(CurrentExp, MaxExp);
        Level++;
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.showPopup);
        UiController.instance.Shopweapon.Show(true);
        UiController.instance.LevelTxt.text = Level.ToString();
    }

    public void ResetLevel()
    {
        InitData();
        Level = 1;
        MaxExp = 100;
        CurrentExp = 0;
        expbar.SetBar(CurrentExp, MaxExp);
        UiController.instance.LevelTxt.text = Level.ToString();
    }

    public void CheckLevelUp()
    {
        if (CurrentExp >= MaxExp)
        {
            SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.LevelUp);
            LevelUp();
        }
    }

    public abstract void Ultimate();
}
