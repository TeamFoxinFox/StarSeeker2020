using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker {
    public class Player : MonoBehaviour
    {
        private float speed = 2;
        private float collisionCooltimeMax = 0.5f;
        private float collisionCooltime;
        private Rigidbody2D rigidbody2d;

        private void Awake() {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            collisionCooltime = Mathf.Min(0, collisionCooltime - Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (collisionCooltime != 0) {
                rigidbody2d.velocity = new Vector3(0, 12, 0);
                collisionCooltime = collisionCooltimeMax;
            }
        }
    }
}