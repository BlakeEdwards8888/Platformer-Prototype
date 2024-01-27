using Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        [Range(0,1)]
        [SerializeField] float jumpCancelMultiplier;

        InputReader inputReader;
        Rigidbody2D rb2d;
        GroundChecker groundChecker;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            rb2d = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
        }

        private void OnEnable()
        {
            inputReader.jumpEvent += Jump;
            inputReader.jumpCanceledEvent += CancelJump;
        }

        private void Jump()
        {
            RaycastHit2D[] results = new RaycastHit2D[1];

            if (groundChecker.IsGrounded() || (groundChecker.IsCoyoteTime() && rb2d.velocity.y <= 0))
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        void CancelJump()
        {
            if(rb2d.velocity.y > 0)
            {
                rb2d.AddForce(Vector2.down * rb2d.velocity.y * (1 - jumpCancelMultiplier), ForceMode2D.Impulse);
            }
        }

        private void OnDisable()
        {
            inputReader.jumpEvent -= Jump;
            inputReader.jumpCanceledEvent -= CancelJump;
        }
    }
}
