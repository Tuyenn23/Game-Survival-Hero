using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class WaveContraint 
{
    [SerializeField] private int[] bonusStep = { 5 };

    [SerializeField] private List<int> startIndexes = new List<int> { 0 };

    [SerializeField] private int startIndex = -1;


    public int CountResourcesObject(string path)
    {
        int _count = 0;

        /*string[] guid = AssetDatabase.FindAssets("t:prefab", new string[] { path });*/

        GameObject[] Resources1 = Resources.LoadAll<GameObject>(path);
        _count = Resources1.Length;

        Debug.Log("co" + Resources1.Length + "wave");

        return _count;
    }





    public int GetWaveCountInResources(WaveType WaveType)
    {
        int levelTypeIntValue = (int)WaveType;
        if (levelTypeIntValue > startIndexes.Count)
        {
            throw new ArgumentOutOfRangeException($"{nameof(startIndexes)} lacks a value for {WaveType}");
        }

        int levelStartIndex = startIndexes[levelTypeIntValue];

        if (levelStartIndex == -1)
        {
            return -1;
        }

        if (levelTypeIntValue + 1 >= startIndexes.Count)
        {
            return CountResourcesObject("LevelNormal/Level_"+GameManager.ins.levelPlaying) - levelStartIndex;


            /* return SceneManager.sceneCountInBuildSettings - levelStartIndex;*/
        }

        return startIndexes[levelTypeIntValue] - levelStartIndex;
    }
}
