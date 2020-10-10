
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starseeker
{
    public class Block : MonoBehaviour
    {
        public int maxHealth;
        [HideInInspector]
        public int floor;
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                health = Mathf.Max(value, 0);
                textMesh.text = value.ToString();
                if (health <= 0)
                {
                    Destroy(gameObject);
                    GameManager.Instance.Score++;
                    Player.Instance.Power = Mathf.Max(Player.Instance.Power, floor);
                }
            }
        }
        private float speed = 0.8f;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2d;
        private TextMesh textMesh;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2d = GetComponent<BoxCollider2D>();
            textMesh = transform.GetChild(0).GetComponent<TextMesh>();
        }

        private void Start()
        {
            Health = maxHealth;
        }

        private void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Health -= Player.Instance.Power;
            }
        }
    }
}