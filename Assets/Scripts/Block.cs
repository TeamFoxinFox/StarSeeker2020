
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker {
    public class Block : MonoBehaviour
    {
        public int maxHealth;
        private int health;
        public int Health {
            get { return health; }
            set {
                health = value;
                textMesh.text = value.ToString();
                if (health <= 0) {
                    Destroy(gameObject);
                }
            }
        }
        private float speed = 0.8f;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2d;
        private TextMesh textMesh;

        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2d = GetComponent<BoxCollider2D>();
            textMesh = transform.GetChild(0).GetComponent<TextMesh>();
        }

        private void Start() {
            Health = maxHealth;
        }

        private void Update() {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.tag == "Player") {
                Health--;
            }
        }
    }
}