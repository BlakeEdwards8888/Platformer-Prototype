using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Faller : MonoBehaviour
    {
        [SerializeField] float gravityScale = 1;
        [SerializeField] float fallingGravityScale = 2.5f;
        [SerializeField] float maxFallSpeed = 50;

        Rigidbody2D rb2d;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if(rb2d.velocity.y < 0)
            {
                rb2d.gravityScale = gravityScale * fallingGravityScale;
            }
            else
            {
                rb2d.gravityScale = gravityScale;
            }
        }

        private void LateUpdate()
        {
            if(rb2d.velocity.y < -maxFallSpeed)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -maxFallSpeed);
            }
        }
    }
}
