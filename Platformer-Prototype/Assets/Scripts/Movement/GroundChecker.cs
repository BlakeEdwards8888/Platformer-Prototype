using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] ContactFilter2D groundFilter;
        [SerializeField] float groundCheckDistance;
        [SerializeField] float coyoteTime;

        Rigidbody2D rb2d;
        float timeSinceGrounded;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (IsGrounded())
            {
                timeSinceGrounded = 0;
            }

            if(IsCoyoteTime())
            {
                timeSinceGrounded += Time.deltaTime;
            }
        }

        public bool IsGrounded()
        {
            RaycastHit2D[] results = new RaycastHit2D[1];

            if(rb2d.Cast(-Vector2.up, groundFilter, results, groundCheckDistance) > 0)
            {
                return true;
            }

            return false;
            
        }

        public bool IsCoyoteTime()
        {
            return timeSinceGrounded < coyoteTime;
        }
    }
}
