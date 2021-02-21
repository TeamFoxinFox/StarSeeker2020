using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    using Table = List<(int, IPattern)>;

    public class LevelTable
    {
        public List<Table> PatternTable;

        public LevelTable()
        {
            PatternTable = new List<Table>();
            var level1 = new List<(int, IPattern)> {
                (100, new SimplePattern())
            };
            PatternTable.Add(level1);
        }

        public Table CurrentTable(int level)
        {
            if (PatternTable.Count <= level)
                throw new InvalidOperationException("Can't find Table from current Level");

            return PatternTable[level];
        }
    }
}