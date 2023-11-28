using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : UICanvas
{
    public TypePlayer TypePlayerCache;
    public int idCache;
    public TypeUnlock TypeUnlockCache;

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);
    }
}
