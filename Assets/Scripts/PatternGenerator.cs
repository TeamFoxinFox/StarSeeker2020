using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    [RequireComponent(typeof(LevelTable))]
    public class PatternGenerator : MonoBehaviour
    {
        public GameObject LvTblPrefab;
        public uint generatedCount = 0;
        public int level = 0;

        private Queue<IPattern> queue = new Queue<IPattern>();
        private GameObject emptyObj;

        private void Start()
        {
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
                var table = GetComponent<LevelTable>().CurrentTable(level);
                foreach (var p_chance in table.table)
                {
                    if (n < p_chance.Percent)
                    {
                        var temp = Instantiate(p_chance.Pattern, transform.position, Quaternion.identity, transform);
                        // var p = temp.AddComponent(p_chance.Pattern.Type) as IPattern;
                        var p = temp.GetComponent<IPattern>();
                        if (p == null)
                            throw new InvalidCastException("Cannot read pattern from table");

                        queue.Enqueue(p);
                        break;
                    }
                    n -= p_chance.Percent;
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