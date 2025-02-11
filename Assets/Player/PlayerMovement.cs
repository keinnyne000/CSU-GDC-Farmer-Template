using UnityEngine;
using Farmer.PlayerInput;

namespace Farmer.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb;
        InputActions inputActions;
        [SerializeField] PlayerMovementInfo info;

        void Start()
        {
            inputActions = new();
            inputActions.Enable();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            Vector2 input = inputActions.Gameplay.WASD.ReadValue<Vector2>();
            input = input.normalized;
            Vector2 movement = input * info.MovementSpeed;
            rb.linearVelocity = movement;
        }
    }
}
