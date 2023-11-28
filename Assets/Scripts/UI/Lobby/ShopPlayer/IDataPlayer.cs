using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPlayer 
{
    public int GetIdPlayer(TypePlayer Type);

    public void SetIdEquipPlayer(TypePlayer Type, int id);
    public bool getUnlockSkin(TypePlayer Type, int id);

    public void setUnlockSkin(TypePlayer Type, int id);
}
