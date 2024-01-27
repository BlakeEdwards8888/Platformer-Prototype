using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float acceleration;
        [SerializeField] float deceleration;
        [SerializeField] float moveSpeed;
        [SerializeField] float velPower;
        [SerializeField] float frictionAmount;
        [SerializeField] float jumpHeightMoveSpeedMultiplier;
        [SerializeField] float jumpHeightBuffer;

        InputReader inputReader;
        Rigidbody2D rb2d;
        GroundChecker groundChecker;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            rb2d = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
        }

        private void FixedUpdate()
        {
            HandlePlayerInput();
            HandleFriction();
        }

        private void HandlePlayerInput()
        {
            float targetSpeed = inputReader.MovementValue.x * moveSpeed;

            if (!groundChecker.IsGrounded() && Mathf.Abs(rb2d.velocity.y) < jumpHeightBuffer)
            {
                targetSpeed *= jumpHeightMoveSpeedMultiplier;
            }

            print(targetSpeed);

            float speedDif = targetSpeed - rb2d.velocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

            rb2d.AddForce(movement * Vector2.right);
        }

        void HandleFriction()
        {
            if (!groundChecker.IsGrounded() || Mathf.Abs(inputReader.MovementValue.x) >= 0.01f) return;

            float amount = Mathf.Min(Mathf.Abs(rb2d.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb2d.velocity.x);

            rb2d.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
    }
}
