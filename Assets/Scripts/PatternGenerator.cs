using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class PatternGenerator : MonoBehaviour
    {
        public LevelTable LevelTable;
        public uint generatedCount = 0;
        public int level = 0;

        private Queue<IPattern> queue;
        private GameObject emptyObj;

        private void Start()
        {
            LevelTable = new LevelTable();
            queue = new Queue<IPattern>();
            emptyObj = new GameObject("PatternObject");

            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                CreateBlock();
                yield return new WaitForSeconds(7f);
            }
        }

        private void CreateBlock()
        {
            if (queue.Count < 1)
            {
                var r = new System.Random();
                var n = r.Next(0, 100);
                var table = LevelTable.CurrentTable(level);
                foreach (var p_chance in table)
                {
                    if (n < p_chance.Item1)
                    {
                        var temp = Instantiate(emptyObj, transform.position, Quaternion.identity, transform);
                        var p = temp.AddComponent(p_chance.Item2.GetType()) as IPattern;
                        queue.Enqueue(p);
                        break;
                    }
                    n -= p_chance.Item1;
                }
            }

            if (queue.Count < 1)
                throw new InvalidOperationException("Cannot generated pattern");

            var pattern = queue.Dequeue();
            pattern.Initialize(5);
            generatedCount++;
        }
    }
}