using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnFX : MonoBehaviour
{
    public float Time;
    void Start()
    {
        StartCoroutine(DespawnFx());
    }

    IEnumerator DespawnFx()
    {
        yield return new WaitForSecondsRealtime(Time);
        Destroy(gameObject);
    }
}
