using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Faller : MonoBehaviour
    {
        [SerializeField] float gravityScale = 1;
        [SerializeField] float fallingGravityScale = 2.5f;

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
    }
}
