using UnityEngine;

namespace Farmer.Player
{
    // This class is a ScriptableObject, so it can be created as an asset in the Unity Editor.
    // It's used to store information about the player's movement in a single place.
    [CreateAssetMenu(fileName = "PlayerMovementInfo", menuName = "Player/PlayerMovementInfo")]
    public class PlayerMovementInfo : ScriptableObject
    {
        [SerializeField] private float movementSpeed = 5f;
        
        public float MovementSpeed => movementSpeed;
    }
}