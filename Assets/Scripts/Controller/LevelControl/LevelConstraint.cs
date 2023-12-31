﻿using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

namespace Unicorn
{
    /// <summary>
    /// Điều kiện để nối Level với Scene Build Index
    /// </summary>
    [Serializable]
    public class LevelConstraint
    {
        [SerializeField] private int[] bonusStep = { 5 };

        [SerializeField] private List<int> startIndexes = new List<int> { 0 };

        [SerializeField] private int startIndex = -1;


        
        public int GetStartIndex()
        {
            if (startIndex != -1) return startIndex;

            startIndex = int.MaxValue;

            foreach (int startIndex in startIndexes)
            {
                this.startIndex = Mathf.Min(this.startIndex, startIndex);
            }

            return startIndex;
        }

        
        public int GetStartIndex(LevelType levelType)
        {
            try
            {
                return startIndexes[(int)levelType];
            }
            catch (ArgumentOutOfRangeException)
            {
                int levelTypeCount = Enum.GetValues(typeof(LevelType)).Length;
                if (levelTypeCount > startIndexes.Count)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(startIndexes)} has less values than {nameof(LevelType)}. There should be {levelTypeCount} values.");

                throw;
            }
        }

        // 
        public int GetLevelCount()
        {
            startIndex = GetStartIndex();
            return CountAmoutFolderInResources("Assets/Resources/LevelNormal") - startIndex + 1;
        }


        public int CountAmoutFolderInResources(string Folderpath)
        {
            int _count = 0;
            string[] subdirectories = Directory.GetDirectories(Folderpath);
            _count = subdirectories.Length;

            Debug.Log("co" + _count + "Level");

            return _count;
        }

/*        public int CountResourcesObject(string path)
        {
            int _count = 0;

            string[] guid = AssetDatabase.FindAssets("t:prefab", new string[] { path });
            _count = guid.Length;
            Debug.Log(_count + "Level");

            return _count;
        }*/


        public int GetLevelCount(LevelType levelType)
        {
            int levelTypeIntValue = (int)levelType;
            if (levelTypeIntValue > startIndexes.Count)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndexes)} lacks a value for {levelType}");
            }

            int levelStartIndex = startIndexes[levelTypeIntValue];

            if (levelStartIndex == -1)
            {
                return -1;
            }

            if (levelTypeIntValue + 1 >= startIndexes.Count)
            {
                return CountAmoutFolderInResources("Assets/Resources/LevelNormal") - levelStartIndex;
               /* return SceneManager.sceneCountInBuildSettings - levelStartIndex;*/
            }

            return startIndexes[levelTypeIntValue] - levelStartIndex;
        }

        public LevelType GetLevelTypeFromBuildIndex(int buildIndex)
        {
            return (LevelType)(buildIndex / GetStartIndex());
        }

        public int GetLevelIndexFromBuildIndex(int buildIndex)
        {
            LevelType levelType = GetLevelTypeFromBuildIndex(buildIndex);
            int startIndex = GetStartIndex(levelType);
            return buildIndex - startIndex;
        }
    }

}