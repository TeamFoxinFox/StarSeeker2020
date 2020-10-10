using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class BlockDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Block"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
