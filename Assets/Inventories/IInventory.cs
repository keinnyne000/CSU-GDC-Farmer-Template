using System;
using System.Collections.Generic;

namespace Farmer.Inventories
{
    // This interface defines the methods that an inventory should implement
    // Interfaces are extremely useful in Unity as they are more flexible than inheritance
    // See how they are used in the ArrayInventory and ValueListInventory classes
    public interface IInventory
    {
        public event Action OnUpdated;
        public (uint, int)[] GetAll();
        public void SetAll((uint, int)[] items);
        public bool HasItem(int slot);
        public bool HasItem(uint id);
        public int WhereItem(uint id);
        
        public (uint, int) PeekItem(int slot);
        public bool PushItem(uint id, int qty, int slot);
        public (uint, int) PopItem(int slot);
        public (uint, int) PopItem(int slot, int qty);

    }
}