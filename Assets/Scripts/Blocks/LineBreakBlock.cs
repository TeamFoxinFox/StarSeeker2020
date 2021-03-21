using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class LineBreakBlock : ImmediateBlock
    {
        public void OnDestroy()
        {
            // foreach (var b in Parent.Blocks)
            // {
            //     Destroy(b);
            // }
            Destroy((MonoBehaviour)Parent);
            // Destroy(Parent);
        }
    }
}