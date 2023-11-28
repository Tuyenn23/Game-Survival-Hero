using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemBase
{
    public override void Use()
    {
        SoundManager.instance.PlayFxSound(SoundManager.instance.SoundData.CoinGold);
        PlayerDataManager.Instance.AddGold(general[0].value);
        UiController.instance.uiMainGameplay._updateCoin?.Invoke();
    }
}
