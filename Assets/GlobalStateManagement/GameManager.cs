using System;
using Farmer.Items;
using Farmer.Player;
using Farmer.SavingAndLoading;
using UnityEngine;

namespace Farmer.GlobalStateManagement
{
    // This class is used to manage the game state, such as saving and loading the world.
    // You have to be extremely careful when making classes like this, as they can easily become entangled with other systems.
    // Setting up the world or saving it is a good use case for a class like this.
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private PlayerInventory inventory;
        [SerializeField] private ItemData defaultItem;
        private void Start()
        {
            SetupWorld();
        }
        
        private void OnApplicationQuit()
        {
            SaveWorld();
        }

        void SetupWorld()
        {
            if(SaveLoadHandler.HasSaveFile())
            {
                WorldSaveData saveData = SaveLoadHandler.LoadGame();
                // Load the player's position
                player.transform.position = saveData.PlayerPosition;
                // Load the player's inventory
                (uint, int)[] playerInventory = new (uint, int)[saveData.PlayerInventoryIds.Length];
                for (int i = 0; i < saveData.PlayerInventoryIds.Length; i++)
                {
                    playerInventory[i] = (saveData.PlayerInventoryIds[i], saveData.PlayerInventoryQuantities[i]);
                }
                inventory.Inventory.SetAll(playerInventory);
            }
            else
            {
                // Set the player's position to the starting position
                player.transform.position = Vector2.zero;
                
                // Set the player's inventory to the starting inventory
                inventory.Inventory.PushItem(defaultItem.Id, 16, 0);
            }
        }

        void SaveWorld()
        {
            // Save the player's position
            Vector2 playerPosition = player.transform.position;

            // Save the player's inventory
            var playerInventory = Array.Empty<(uint, int)>();
            
            uint[] playerInventoryIds = new uint[inventory.Capacity];
            int[] playerInventoryQuantities = new int[inventory.Capacity];
            for (int i = 0; i < inventory.Capacity; i++)
            {
                var item = inventory.Inventory.PeekItem(i);
                playerInventoryIds[i] = item.Item1;
                playerInventoryQuantities[i] = item.Item2;
            }
            
            SaveLoadHandler.SaveGame(playerPosition, playerInventoryIds, playerInventoryQuantities);
        }

    }
}