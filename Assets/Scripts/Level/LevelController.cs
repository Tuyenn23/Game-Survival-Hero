using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : LevelManager
{
    public Sprite Bg;

    public override void StartLevel()
    {
        PrefabStorage.Instance.BG.GetComponent<SpriteRenderer>().sprite = Bg;
    }
}
