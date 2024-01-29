using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class FrictionHandler : MonoBehaviour
    {
        [SerializeField] float frictionAmount;

        Rigidbody2D rb2d;
        GroundChecker groundChecker;
        InputReader inputReader;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
            inputReader = GetComponent<InputReader>();
        }

        private void FixedUpdate()
        {
            if (!groundChecker.IsGrounded() || Mathf.Abs(inputReader.MovementValue.x) >= 0.01f) return;

            float amount = Mathf.Min(Mathf.Abs(rb2d.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb2d.velocity.x);

            rb2d.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
    }
}
