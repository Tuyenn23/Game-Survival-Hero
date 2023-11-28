using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : ItemBase
{
    public override void Use()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.CoinDiamond);
        PlayerDataManager.Instance.AddDiamond(general[0].value);
        UiController.instance.uiMainGameplay._updateCoin?.Invoke();
    }
}
