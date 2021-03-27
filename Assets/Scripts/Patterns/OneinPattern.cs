using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{

    [Serializable]
    public class OneinPattern : MonoBehaviour, IPattern
    {
        public int Health { get; }
        public List<GameObject> Blocks { get; protected set; }
        [HideInInspector]
        public GameObject DefaultBlockPrefab;
        public GameObject SpecialBlockPrefab;

        public void Awake()
        {
            var prefab1 = Resources.Load("Prefabs/Block") as GameObject;
            var prefab2 = Resources.Load("Prefabs/LineBreakBlock") as GameObject;
            Blocks = new List<GameObject>();
            DefaultBlockPrefab = prefab1;
            SpecialBlockPrefab = prefab2;
        }

        public void OnDestroy()
        {
            foreach (var block in Blocks)
            {
                Destroy(block);
            }
        }

        public void Initialize(int Health)
        {
            var n = new System.Random().Next(0, 8);

            for (int xoffSet = -4, i = 0; i < 9; i++)
            {
                GameObject obj = Instantiate(
                    i == n ? SpecialBlockPrefab : DefaultBlockPrefab,
                    transform.position + new Vector3(xoffSet + i, 0, 0),
                    Quaternion.identity,
                    transform);

                var block = obj.GetComponent<Block>();
                block.Health = Health;
                block.Parent = this;
                Blocks.Add(obj);
            }
        }
    }
}