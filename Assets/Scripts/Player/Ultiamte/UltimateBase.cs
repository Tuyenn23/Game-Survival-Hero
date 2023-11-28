using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;

public abstract class UltimateBase : MonoBehaviour
{
    public int Damage;
    public Collider2D boxCollider2D;
    public float timeDestroy;

    public abstract IEnumerator AniEvent();
}
