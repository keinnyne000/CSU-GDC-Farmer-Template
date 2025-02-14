using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Farmer.Items
{
    // This class is a ScriptableObject, so it can be created as an asset in the Unity Editor.
    // It's used to store a list of ItemData, and to retrieve the correct item for a given ID.
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