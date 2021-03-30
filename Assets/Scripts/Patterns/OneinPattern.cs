using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{

    [Serializable]
    public class OneinPattern : SimplePattern
    {
        public GameObject SpecialBlock;

        public override void Initialize(int Health)
        {
            var n = new System.Random().Next(0, 8);

            for (int xoffSet = -4, i = 0; i < 9; i++)
            {
                GameObject obj = Instantiate(
                    i == n ? SpecialBlock : DefaultBlock,
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