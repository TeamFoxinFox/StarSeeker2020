using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TypeReferences;

namespace Starseeker
{
    [ExecuteInEditMode]
    public class LevelTable : MonoBehaviour
    {
        [Serializable]
        public class Level
        {
            [System.Serializable]
            public struct Chance
            {
                public int Percent;
                public GameObject Pattern;
            }
            public List<Chance> table = new List<Chance>();
        }

        public List<Level> Levels = new List<Level>();
        public LevelTable()
        {
        }

        public Level CurrentTable(int level)
        {
            if (Levels.Count <= level)
                throw new InvalidOperationException("Can't find Table from current Level");

            return Levels[level];
        }

    }
}