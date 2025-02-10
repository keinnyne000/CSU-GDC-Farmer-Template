using System.Collections.Generic;

namespace Farmer.Inventories
{
    public class ValueListInventory : IInventory
    {
        public int Capacity { get; private set; }
        List<(uint, int)> items = new(); // (id, qty)
        
        public ValueListInventory(int capacity)
        {
            Capacity = capacity;
        }
        
        public bool HasItem(int slot)
        {
            return (items[slot].Item1 != 0);
        }

        public bool HasItem(uint id)
        {
            foreach (var item in items)
                if(item.Item1 == id)
                    return true;
            
            return false;
        }

        public int WhereItem(uint id)
        {
            for (int i = 0; i < items.Count; i++)
                if (items[i].Item1 == id)
                    return i;
            
            return -1;
        }

        public (uint, int) PeekItem(int slot)
        {
            return items[slot];
        }

        public bool PushItem(uint id, int qty, int slot)
        {
            if (slot < 0 || slot >= Capacity)
                return false;
            
            items[slot] = (id, qty);
            return true;
        }

        public (uint, int) PopItem(int slot, int qty)
        {
            var item = items[slot];
            if (item.Item2 > qty)
            {
                items[slot] = (item.Item1, item.Item2 - qty);
                return (item.Item1, qty);
            }
            else
            {
                items[slot] = (0, 0);
                return item;
            }
        }
    }
}