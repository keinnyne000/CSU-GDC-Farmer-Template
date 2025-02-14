using System;
using System.Collections.Generic;
using System.Linq;

namespace Farmer.Inventories
{
    // This is another implementation of the IInventory interface
    // It is not used in the game, but it is a good example of how to implement the interface
    public class ValueListInventory : IInventory
    {
        public int Capacity { get; private set; }
        List<(uint, int)> items = new(); // (id, qty)
        
        public ValueListInventory(int capacity)
        {
            Capacity = capacity;
        }

        public event Action OnUpdated;

        public (uint, int)[] GetAll()
        {
            return items.ToArray();
        }

        public void SetAll((uint, int)[] items)
        {
            this.items = items.ToList();
            OnUpdated?.Invoke();
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
            OnUpdated?.Invoke();
            return true;
        }

        public (uint, int) PopItem(int slot)
        {
            var item = items[slot];
            items[slot] = (0, 0);
            OnUpdated?.Invoke();
            return item;
        }

        public (uint, int) PopItem(int slot, int qty)
        {
            var item = items[slot];
            if (item.Item2 > qty)
            {
                items[slot] = (item.Item1, item.Item2 - qty);
                OnUpdated?.Invoke();
                return (item.Item1, qty);
            }
            else
            {
                items[slot] = (0, 0);
                OnUpdated?.Invoke();
                return item;
            }
        }
    }
}