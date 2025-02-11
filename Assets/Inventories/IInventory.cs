using System;
using System.Collections.Generic;

namespace Farmer.Inventories
{
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