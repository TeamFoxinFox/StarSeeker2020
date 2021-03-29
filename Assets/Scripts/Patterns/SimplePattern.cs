using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    [Serializable]
    public class SimplePattern : MonoBehaviour, IPattern
    {
        public int Health { get; }
        public List<GameObject> Blocks { get; protected set; }
        public GameObject DefaultBlockPrefab;

        public void Awake()
        {
            var prefab = Resources.Load("Prefabs/Block") as GameObject;
            Blocks = new List<GameObject>();
            DefaultBlockPrefab = prefab;
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
            for (int xoffSet = -4, i = 0; i < 9; i++)
            {
                GameObject obj = Instantiate(
                    DefaultBlockPrefab,
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