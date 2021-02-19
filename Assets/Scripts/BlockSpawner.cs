using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class BlockSpawner : MonoBehaviour
    {
        public GameObject blockPrefab;
        private int currentFloor = 2;
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
                CreateBlock(currentFloor);
                currentFloor++;
                yield return new WaitForSeconds(7f);
            }
        }

        private void CreateBlock(int floor)
        {
            var temp = Instantiate(emptyObj, transform.position, Quaternion.identity, transform);
            var sp = temp.AddComponent<SimplePattern>();
            sp.Initialize(5);
        }
    }
}