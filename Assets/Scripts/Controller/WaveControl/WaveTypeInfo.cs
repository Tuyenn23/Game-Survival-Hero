using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveTypeInfo
{
    private WaveType waveType;
    private int currentWave = 1;
    private int maxLevel = int.MinValue;

    public WaveType WaveType
    {
        get => waveType;
        set => waveType = value;
    }

    public int CurrentLevel
    {
        get => currentWave;
        set => currentWave = value;
    }


    public int MaxLevel => maxLevel;

    public WaveTypeInfo(WaveType waveType)
    {
        this.waveType = waveType;
    }

    public int IncreaseLevel(WaveContraint waveConstraint)
    {
        var WaveCount = waveConstraint.GetWaveCountInResources(waveType);
        currentWave++;
        maxLevel = Mathf.Max(maxLevel, currentWave);

        if (maxLevel <= WaveCount) return currentWave;

        currentWave = 1;
        maxLevel = 1;
        return currentWave;
    }

    public void SetLevel(int level, WaveContraint waveContraint)
    {
        var levelCount = waveContraint.GetWaveCountInResources(waveType);
        currentWave = Mathf.Clamp(level, 1, levelCount);
    }
}
