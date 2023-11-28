using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerDataManager : MonoBehaviour, IDataPlayer
{
    public static PlayerDataManager Instance;
    private IDataLevel dataLevel;

    private void Awake()
    {
        Instance = this;
        dataLevel = null;
    }

    public void DefaultData()
    {
/*        SetDiamond(0);
        SetGold(0);
        setUnlockSkin(TypePlayer.Default,0);
        SetIdEquipPlayer(TypePlayer.Default, 0);*/
        DataLevel1.SetLevel(1);
        PlayerPrefs.DeleteAll();
    }

    public IDataLevel GetDataLevel(LevelConstraint levelConstraint)
    {
        var dataLevelJson = PlayerPrefs.GetString(Helper.DataLevel, string.Empty);
        dataLevel = dataLevelJson == string.Empty
            ? new DataLevel(levelConstraint)
            : JsonConvert.DeserializeObject<DataLevel>(dataLevelJson);

        return dataLevel ?? new DataLevel(levelConstraint);
    }

    public void SetDataLevel(IDataLevel dataLevel)
    {
        this.dataLevel = dataLevel;
        PlayerPrefs.SetString(Helper.DataLevel, JsonConvert.SerializeObject(dataLevel));
    }

    public IDataWave GetDataWave(WaveContraint waveContraint)
    {
        return new DataWave(waveContraint);
    }

    public int GetIdPlayer(TypePlayer Type)
    {
        return PlayerPrefs.GetInt(Helper.DataPlayer + Type, -1);
    }

    public void SetIdEquipPlayer(TypePlayer Type, int id)
    {
        PlayerPrefs.SetInt(Helper.DataPlayer + Type, id);
    }

    public void setUnlockSkin(TypePlayer Type, int id)
    {
        PlayerPrefs.SetInt(Helper.DataPlayer + Type + id, 1);
    }

    public bool getUnlockSkin(TypePlayer Type, int id)
    {
        return PlayerPrefs.GetInt(Helper.DataPlayer + Type + id, 0) == 0 ? false : true;
    }

    public int GetGold()
    {
        return PlayerPrefs.GetInt(Helper.GOLD, 0);
    }

    public void SetGold(int _count)
    {
        PlayerPrefs.SetInt(Helper.GOLD, _count);
    }

    public int GetDiamond()
    {
        return PlayerPrefs.GetInt(Helper.DIAMOND, 0);
    }

    public void SetDiamond(int _count)
    {
        PlayerPrefs.SetInt(Helper.DIAMOND, _count);
    }

    public void AddGold(int AmountAdd)
    {
        int count = GetGold() + AmountAdd;
        SetGold(count);
    }

    public void AddDiamond(int AmountAdd)
    {
        int count = GetDiamond() + AmountAdd;
        SetDiamond(count);
    }

    public int getCoinByType(TypeUnlock Type)
    {
        if(Type == TypeUnlock.Gold)
        {
            return GetGold();
        }
        else
        {
            return GetDiamond();
        }
    }

    public void AddCoinByType(TypeUnlock Type,int _count)
    {
        if(Type == TypeUnlock.Gold)
        {
            AddGold(_count);
        }
        else
        {
            AddDiamond(_count);
        }
    }

    public bool GetMusicBg()
    {
        return PlayerPrefs.GetInt(Helper.MusicBg, 1) == 1;
    }

    public void SetMusicBg(bool isOn)
    {
        PlayerPrefs.SetInt(Helper.MusicBg, isOn ? 1 : 0);
    }

    public bool GetRung()
    {
        return PlayerPrefs.GetInt(Helper.Rung, 1) == 1;
    }

    public void SetRung(bool isOn)
    {
        PlayerPrefs.SetInt(Helper.Rung, isOn ? 1 : 0);
    }

    public bool GetMusic()
    {
        return PlayerPrefs.GetInt(Helper.Music, 1) == 1;
    }

    public void SetMusic(bool isOn)
    {
        PlayerPrefs.SetInt(Helper.Music, isOn ? 1 : 0);
    }
}
