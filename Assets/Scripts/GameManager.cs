using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } = null;
        public int Score { get; set; } = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}