using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Farmer.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb;
        InputActions inputActions;
        [SerializeField] private PlayerMovementInfo info;

        Vector2 recentMovement;
        Vector2 lastInput;
        void Start()
        {
            inputActions = new();
            inputActions.Enable();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Vector2 input = inputActions.Gameplay.WASD.ReadValue<Vector2>();
            Vector2 dir = input;
            if (lastInput != input && input.magnitude > 1)
            {
                dir = math.normalize(math.normalize(input) - math.normalize(lastInput));
            }
            lastInput = input;
            
            Vector2 movement = dir * info.MovementSpeed;
            recentMovement = movement;
            rb.linearVelocity = movement;
        }
    }
}
