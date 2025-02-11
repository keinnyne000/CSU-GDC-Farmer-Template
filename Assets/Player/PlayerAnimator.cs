

using UnityEngine;

namespace Farmer.Player.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Rigidbody2D rb;


        void Update()
        {
            Animate();
        }

        void Animate()
        {
            animator.SetFloat("Horizontal", rb.linearVelocityX);
            animator.SetFloat("Vertical", rb.linearVelocityY);
            animator.SetFloat("Speed", rb.linearVelocity.magnitude);
        }
    }
}