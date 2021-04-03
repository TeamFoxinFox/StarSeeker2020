using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; } = null;

        public class Status
        {
            public int power = 1;
            public Vector2 speed = new Vector2(2f, 14f);

        }
        public Status status = new Status();

        private float collisionCooltimeMax = 0.5f;
        private float collisionCooltime;
        private Rigidbody2D rigidbody2d;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            collisionCooltime = Mathf.Min(0, collisionCooltime - Time.deltaTime);

            float hMoved = Input.GetAxis("Horizontal");
            if (hMoved != 0)
            {
                transform.Translate((hMoved < 0 ? Vector3.left : Vector3.right) * status.speed.x * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Block") && collisionCooltime != 0)
            {
                var block = collision.gameObject.GetComponent<Block>();
                rigidbody2d.velocity = new Vector3(0, block.springPower * status.speed.y, 0);
                collisionCooltime = collisionCooltimeMax;
            }
        }
    }
}