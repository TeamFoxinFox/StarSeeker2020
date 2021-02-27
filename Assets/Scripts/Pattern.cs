using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public interface IPattern
    {
        int Health { get; }
        List<Block> Blocks { get; }

        void Initialize(int Health);
        bool IsDestoryedAll();
    }

    public class SimplePattern : MonoBehaviour, IPattern
    {
        public int Health { get; }
        public List<Block> Blocks { get; protected set; }
        [HideInInspector]
        public GameObject DefaultBlockPrefab;

        public void Awake()
        {
            var prefab = Resources.Load("Prefabs/Block") as GameObject;
            Blocks = new List<Block>();
            DefaultBlockPrefab = prefab;
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
                Blocks.Add(block);
            }
        }

        public bool IsDestoryedAll()
        {
            throw new NotImplementedException();
        }
    }
}