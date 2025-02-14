using UnityEngine;
using Farmer.PlayerInput;

namespace Farmer.Player
{
    // This class is used to move the player character around the scene
    // Note for this to work, you need to have a Rigidbody2D component attached to the player GameObject
    // Here's a good video on how to do this (and add animations): https://www.youtube.com/watch?v=whzomFgjT50
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
