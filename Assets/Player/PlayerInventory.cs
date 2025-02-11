using Farmer.Inventories;
using UnityEngine;

namespace Farmer.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] int capacity = 20;
        public ValueListInventory Inventory;

        private void OnEnable()
        {
            Inventory = new ValueListInventory(capacity);
        }
         
        
    }
}