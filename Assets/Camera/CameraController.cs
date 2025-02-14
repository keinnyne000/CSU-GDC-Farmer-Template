using UnityEngine;

namespace Farmer.Camera
{
    // This class is responsible for controlling the camera
    // It should be attached (or a parent of) the camera object
    public class CameraController : MonoBehaviour
    {
        [SerializeField] GameObject player;
        
        void LateUpdate()
        {
            transform.position = player.transform.position;
        }
    }
}