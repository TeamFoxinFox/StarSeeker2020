using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class LineBreakBlock : Block
    {
        public void OnDestroy()
        {
            Destroy((MonoBehaviour)Parent);
        }
    }
}