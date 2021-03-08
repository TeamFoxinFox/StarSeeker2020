using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace GameScene {
    public class Player : MonoSingleton<Player>
    {
        private Rigidbody2D rigidbody2d;
        
        private const float BounceCooldown = 0.5f;
        private const float HorizontalMoveSpeed = 2;
        
        private int power = 1;
        private float bounceTimeLeft = BounceCooldown;
        private List<Status> status = new List<Status>();
        
        public int Power
        {
            get => power;
            set => power = Mathf.Max(0, value);
        }
        private float RemainingBounceCooldown
        {
            get => bounceTimeLeft;
            set => bounceTimeLeft = Mathf.Clamp(value, 0, BounceCooldown);
        }

        private void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            UpdateRemainingCollisionCooldown(Time.deltaTime);
            MoveHorizontally(Time.deltaTime);
        }

        private void UpdateRemainingCollisionCooldown(float deltaTime)
        {
            RemainingBounceCooldown -= deltaTime;
        }

        private void MoveHorizontally(float deltaTime)
        {
            var moveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow)) moveDirection = Vector3.left;
            else if (Input.GetKey(KeyCode.RightArrow)) moveDirection = Vector3.right;
            transform.Translate(moveDirection * (HorizontalMoveSpeed * deltaTime));
        }

        private void OnCollisionEnter2D()
        {
            if (bounceTimeLeft != 0) return;
            rigidbody2d.velocity = new Vector3(0, 12, 0);
            bounceTimeLeft = BounceCooldown;
        }

        public void DestroyStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}