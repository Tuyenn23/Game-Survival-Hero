using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWave : IDataWave, IWaveInfo
{
    private WaveType waveType = WaveType.Normal;

    private int displayWave = 1;
    private Dictionary<WaveType, WaveTypeInfo> waveTypeIndex;

    private WaveContraint waveContraint;

    public WaveContraint WaveContraint
    {
        get
        {
            {
                if (waveContraint == null)
                {
                    Debug.LogError(nameof(waveContraint) + " is not set, using default values!");
                    waveContraint = new WaveContraint();
                }

                return waveContraint;
            }
        }

        set => waveContraint = value;
    }

    private Dictionary<WaveType,WaveTypeInfo> WaveTypeIndex
    {
        get
        {
            if(waveTypeIndex.Count < Enum.GetValues(typeof(WaveType)).Length)
            {
                foreach (WaveType Type in Enum.GetValues(typeof(WaveType)))
                {
                    if (waveTypeIndex.ContainsKey(Type)) continue;
                    waveTypeIndex.Add(Type, new WaveTypeInfo(WaveType));
                }
            }
            return waveTypeIndex;
        }
        set => waveTypeIndex = value;
    }

    public override string ToString()
    {
        return $"Wave: {getCurrentWave()}, " +
               $"{nameof(WaveType)}: {WaveType}";
    }





    public WaveType WaveType => waveType;

    public int DisplayWave => displayWave;

    public int getCurrentWave() => WaveTypeIndex[waveType].CurrentLevel;
    public DataWave(WaveContraint waveContraint)
    {
        WaveTypeIndex = new Dictionary<WaveType, WaveTypeInfo>();
        foreach (WaveType WaveType in Enum.GetValues(typeof(WaveType)))
        {
            if (WaveTypeIndex.ContainsKey(WaveType)) continue;
            WaveTypeIndex.Add(WaveType, new WaveTypeInfo(WaveType));
        }
    }

    public void IncreaseWave()
    {
        displayWave++;

        WaveTypeIndex[waveType].IncreaseLevel(waveContraint);
    }

    public void SetWave(WaveType waveType, int level)
    {
        WaveTypeIndex[waveType].SetLevel(level, WaveContraint);

        this.waveType = waveType;
    }
}
