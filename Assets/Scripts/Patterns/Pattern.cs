using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public interface IPattern
    {
        int Health { get; }
        List<GameObject> Blocks { get; }

        void Initialize(int Health);
    }
}