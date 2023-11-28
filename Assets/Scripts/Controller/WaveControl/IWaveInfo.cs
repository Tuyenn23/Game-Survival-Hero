using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveInfo
{
    WaveType WaveType { get; }

    int DisplayWave { get; }

    int getCurrentWave();
}
