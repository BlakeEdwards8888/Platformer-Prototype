using UnityEngine;

namespace Platformer.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float acceleration;
        [SerializeField] float deceleration;
        [SerializeField] float topSpeed;
        [SerializeField] float jumpApexSpeedMultiplier;
        [SerializeField] float jumpApexBuffer;

        Rigidbody2D rb2d;
        GroundChecker groundChecker;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
        }

        public void Move(float direction)
        {
            float targetSpeed = direction * topSpeed;

            if (!groundChecker.IsGrounded() && Mathf.Abs(rb2d.velocity.y) < jumpApexBuffer)
            {
                targetSpeed *= jumpApexSpeedMultiplier;
            }

            float speedDif = targetSpeed - rb2d.velocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
            float movement = speedDif * accelRate;

            rb2d.AddForce(movement * Vector2.right);
        }
    }
}
