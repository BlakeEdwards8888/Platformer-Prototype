using Platformer.Movement;
using UnityEngine;

namespace Input
{
    public class PlayerController : MonoBehaviour
    {
        InputReader inputReader;
        Mover mover;
        Jumper jumper;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            mover = GetComponent<Mover>();
            jumper = GetComponent<Jumper>();
        }

        private void OnEnable()
        {
            inputReader.jumpEvent += jumper.Jump;
            inputReader.jumpCanceledEvent += jumper.CancelJump;
        }

        private void FixedUpdate()
        {
            mover.Move(inputReader.MovementValue.x);
        }

        private void OnDisable()
        {
            inputReader.jumpEvent -= jumper.Jump;
            inputReader.jumpCanceledEvent -= jumper.CancelJump;
        }
    }
}
