using UnityEngine;

namespace Farmer.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] GameObject player;
        
        void LateUpdate()
        {
            transform.position = player.transform.position;
        }
    }
}