using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; } = null;
        public int Power { get; set; } = 1;
        private float speed = 2;
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

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Block") && collisionCooltime != 0)
            {
                var block = collision.gameObject.GetComponent<Block>();
                rigidbody2d.velocity = block.springPower;
                collisionCooltime = collisionCooltimeMax;
            }
        }
    }
}