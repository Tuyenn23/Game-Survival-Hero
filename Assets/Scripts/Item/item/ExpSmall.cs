using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSmall : ItemBase
{
    public override void Use()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.AnExp);
        PrefabStorage.Instance.Player.CurrentExp += general[0].value;
        PrefabStorage.Instance.Player.expbar.SetBar(PrefabStorage.Instance.Player.CurrentExp, PrefabStorage.Instance.Player.MaxExp);
        PrefabStorage.Instance.Player.CheckLevelUp();
    }
}
