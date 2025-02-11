using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Farmer.Items
{
    [CreateAssetMenu(menuName = "Items/ItemRegistry")]
    public class ItemRegistry : ScriptableObject
    {
        [SerializeField] List<ItemData> items = new();

        public List<ItemData> GetAll()
        {
            return items.ToList();
        }
        
        public ItemData GetItem(uint id)
        {
            foreach (var item in items)
                if (item.Id == id)
                    return item;
            
            return null;
        }
    }
}