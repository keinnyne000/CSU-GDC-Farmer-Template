using UnityEngine;

namespace Farmer.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Rigidbody2D rb;

        void Update()
        {
            Animate();
        }
        
        // These parameters are used in the animator (a Unity component) to control the animations
        // You can check out a video on how to do exactly this here: https://www.youtube.com/watch?v=whzomFgjT50
        void Animate()
        {
            animator.SetFloat("Horizontal", rb.linearVelocityX);
            animator.SetFloat("Vertical", rb.linearVelocityY);
            animator.SetFloat("Speed", rb.linearVelocity.magnitude);
        }
    }
}