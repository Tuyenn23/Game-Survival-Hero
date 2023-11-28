using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataWave : IWaveInfo
{
    WaveContraint WaveContraint { get; }

    void SetWave(WaveType waveType, int level);

    void IncreaseWave();
}
