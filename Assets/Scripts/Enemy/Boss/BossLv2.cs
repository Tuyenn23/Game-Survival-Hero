using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv2 : BossBase
{
    public List<Transform> L_PosCaulua;
    protected override void Start()
    {
        base.Start();
        Move();
        StartCoroutine(Skill1());
    }
    protected override void Move()
    {
        if (PrefabStorage.Instance.Player != null)
        {
            _move = transform.DOMove(PrefabStorage.Instance.Player.transform.position + new Vector3(0, 10, 0), 4f).SetLoops(1, LoopType.Yoyo).OnUpdate(() =>
            {
                _move.ChangeEndValue(PrefabStorage.Instance.Player.transform.position + new Vector3(0, 10, 0), true);
            });
        }
    }

    public virtual IEnumerator Skill1()
    {
        while (isDead == false)
        {
            yield return new WaitForSeconds(2f);
            Skill skill = Instantiate(PrefabStorage.Instance.Skillcaulua, getRandPos(), Quaternion.identity);
            skill.Boss = this;
        }
    }

    public Vector3 getRandPos()
    {
        int rand = Random.Range(0, L_PosCaulua.Count);

        return L_PosCaulua[rand].position;
    }
}
