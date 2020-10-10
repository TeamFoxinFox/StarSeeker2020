using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class MainCamera : MonoBehaviour
    {
        public GameObject player;

        private void Start()
        {
            StartCoroutine(ChasePlayerCoroutine());
        }

        private IEnumerator ChasePlayerCoroutine()
        {
            while (transform.position.y > 0)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4f);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}