using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class BlockSpawner : MonoBehaviour
    {
        public GameObject blockPrefab;
        private int currentFloor = 2;

        private void Start()
        {
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
            int xoffSet = -4;
            for (int i = 0; i < 9; i++)
            {
                GameObject obj = Instantiate(blockPrefab, transform.position + new Vector3(xoffSet + i, 0, 0), Quaternion.identity, transform);
                obj.GetComponent<Block>().floor = floor;
            }
        }
    }
}