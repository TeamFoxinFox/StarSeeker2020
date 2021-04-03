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
                textMesh.text = value.ToString();
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        protected float speed = 0.8f;

        public IPattern Parent;

        public Vector3 springPower = new Vector3(0, 12, 0);

        protected SpriteRenderer spriteRenderer;
        protected BoxCollider2D boxCollider2d;
        protected TextMesh textMesh;

        protected void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2d = GetComponent<BoxCollider2D>();
            textMesh = transform.GetChild(0).GetComponent<TextMesh>();
        }

        public void OnDestroy()
        {
            GameManager.Instance.Score += Score;
            Player.Instance.Power = Mathf.Max(Player.Instance.Power, floor);
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
                Health -= Player.Instance.Power;
            }
        }
        protected bool IsPlayerCollisioned(Collision2D collision)
        {
            return collision.gameObject.CompareTag("Player");
        }
    }
}