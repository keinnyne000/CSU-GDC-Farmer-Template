using UnityEngine;

namespace Farmer.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] private float lerpStrength = 0.1f;
        
        void LateUpdate()
        {
            transform.position =
                Vector2.Lerp(transform.position, player.transform.position, lerpStrength * Time.deltaTime);
        }
    }
}