using UnityEngine;
using UnityEngine.Serialization;

namespace Farmer.SavingAndLoading
{
    // This class is used to store the data that will be saved and loaded for the world.
    // You can add any other data you want to save here.
    [System.Serializable]
    public class WorldSaveData
    {
        public WorldSaveData(Vector2 playerPosition, (uint, int)[] playerInventory)
        {
            this.PlayerPosition = playerPosition;
            this.PlayerInventory = playerInventory;
        }
        
        public Vector2 PlayerPosition;
        public (uint, int)[] PlayerInventory;
    }
}