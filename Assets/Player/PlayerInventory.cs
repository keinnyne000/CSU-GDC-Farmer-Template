using System;
using Farmer.Inventories;
using Farmer.Items;
using UnityEngine;

namespace Farmer.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public event Action<int> OnHotbarIndexChanged;
        
        [SerializeField] private ItemData TEST_item;
        [field: SerializeField] public int Capacity { get; private set; } = 36;
        [field: SerializeField] public int HotbarCapacity { get; private set; } = 12;
        public ArrayInventory Inventory;
        int hotbarIndex = -1;

        private void OnEnable()
        {
            Inventory = new ArrayInventory(Capacity);
            TEST_AddItem();
        }

        void TEST_AddItem()
        {
            Inventory.PushItem(TEST_item.Id, 16, 0);
        }

        private void Start()
        {
            SetHotbarIndex(0);
        }

        public void UseHotbarItem()
        {
            if (Inventory.HasItem(hotbarIndex))
            {
                var item =Inventory.PeekItem(hotbarIndex);
                Debug.Log(item.Item2);
            }
        }

        public void SetHotbarIndex(int index)
        {
            if (index != hotbarIndex && index >= 0 && index < HotbarCapacity)
            {
                hotbarIndex = index;
                OnHotbarIndexChanged?.Invoke(hotbarIndex);  
            }
        }

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