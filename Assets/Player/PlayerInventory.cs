using System;
using Farmer.Inventories;
using Farmer.Items;
using Farmer.Items.Behaviors;
using UnityEngine;

namespace Farmer.Player
{
    // This class is responsible for managing the player's inventory.
    public class PlayerInventory : MonoBehaviour
    {
        
        // This is an event used to seamlessly notify other classes when the hotbar index changes!
        // A messier alternative would be to have a reference to the PlayerInventory in every class
        // that needs to know the hotbar index:
        public event Action<int> OnHotbarIndexChanged;
        
        // This is a reference used to add an item to the inventory in the OnEnable method.
        [field: SerializeField] public int Capacity { get; private set; } = 36;
        [field: SerializeField] public int HotbarCapacity { get; private set; } = 12;
        [SerializeField] ItemBehaviorRegistry itemBehaviorRegistry;
        public ArrayInventory Inventory;
        int hotbarIndex = -1;

        private void OnEnable()
        {
            Inventory = new ArrayInventory(Capacity);
        }
        
        private void Start()
        {
            SetHotbarIndex(0);
        }
    
        // This method is called by the PlayerInput class when the player presses the interact key (LMB).
        public void UseHotbarItem()
        {
            if (Inventory.HasItem(hotbarIndex))
            {
                var item =Inventory.PeekItem(hotbarIndex);
                itemBehaviorRegistry.GetBehavior(item.Item1)?.Use(this, hotbarIndex);
            }
        }
        
        // This method is called by the PlayerInput class when the player presses the hotbar keys (1, 2,...).
        public void SetHotbarIndex(int index)
        {
            if (index != hotbarIndex && index >= 0 && index < HotbarCapacity)
            {
                hotbarIndex = index;
                OnHotbarIndexChanged?.Invoke(hotbarIndex);  
            }
        }
        
        // This method is used to move an item from one slot to another.
        public void TryMoveItem(int fromSlot, int toSlot)
        {
            if(fromSlot < 0 || fromSlot >= Capacity || toSlot < 0 || toSlot >= Capacity)
                return;
            
            IInventory inventory = Inventory;
            
            if(!inventory.HasItem(fromSlot) || inventory.HasItem(toSlot))
                return;
            
            var item = inventory.PopItem(fromSlot);
            inventory.PushItem(item.Item1, item.Item2, toSlot);
        }
    }
}