using Farmer.Inventories;
using Farmer.Items;
using UnityEngine;
using UnityEngine.Serialization;

namespace Farmer.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private ItemData TEST_item;
        [field: SerializeField] public int Capacity { get; private set; } = 36;
        public ArrayInventory Inventory;

        private void OnEnable()
        {
            Inventory = new ArrayInventory(Capacity);
            TEST_AddItem();
        }
        
        void TEST_AddItem()
        {
            Inventory.PushItem(TEST_item.Id, 16, 0);
        }

        public void TryMoveItem(int fromSlot, int toSlot)
        {
            Debug.Log("Trying to move item from " + fromSlot + " to " + toSlot);
            
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