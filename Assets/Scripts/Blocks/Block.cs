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
        public int Score = 1;
        protected int health;
        public int Health
        {
            get { return health; }
            set
            {
                health = Mathf.Max(value, 0);
                if (textMesh)
                    textMesh.text = value.ToString();
                if (health <= 0)
                {
                    Destroy(gameObject);
                    Parent.Powerup();
                }
            }
        }
        protected float speed = 0.8f;

        public IPattern Parent;

        public float springPower = 1;

        protected SpriteRenderer spriteRenderer;
        protected BoxCollider2D boxCollider2d;
        protected TextMesh? textMesh = null;

        protected void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2d = GetComponent<BoxCollider2D>();
            // TODO: blocks child can expandible
            if (transform.childCount != 0)
                textMesh = transform.GetChild(0).GetComponent<TextMesh>();
        }

        public void OnDestroy()
        {
            GameManager.Instance.Score += Score;
        }

        protected void Start()
        {
            Health = maxHealth;
        }

        protected void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        virtual protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsPlayerCollisioned(collision))
            {
                Health -= Player.Instance.status.power;
            }
        }
        protected bool IsPlayerCollisioned(Collision2D collision)
        {
            return collision.gameObject.CompareTag("Player");
        }
    }
}