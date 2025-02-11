using UnityEngine;

namespace Farmer.Player
{
    [CreateAssetMenu(fileName = "PlayerMovementInfo", menuName = "Player/PlayerMovementInfo")]
    public class PlayerMovementInfo : ScriptableObject
    {
        [SerializeField] private float movementSpeed = 5f;
        
        public float MovementSpeed => movementSpeed;
    }
}