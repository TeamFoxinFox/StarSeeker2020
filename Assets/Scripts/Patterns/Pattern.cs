using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public abstract class IPattern : MonoBehaviour
    {
        public int Health { get; }
        public List<GameObject> Blocks { get; protected set; }

        public abstract void Initialize(int Health);

        private bool IsPierced = false;
        public void Powerup()
        {
            if (!IsPierced)
            {
                Player.Instance.Power++;
                IsPierced = true;
            }
        }
    }
}