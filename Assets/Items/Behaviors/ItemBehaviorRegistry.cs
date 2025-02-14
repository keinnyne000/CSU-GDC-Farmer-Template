using UnityEngine;

namespace Farmer.Items.Behaviors
{
    // This class is a ScriptableObject, so it can be created as an asset in the Unity Editor.
    // It is used to store a list of ItemBehaviors, and to retrieve the correct behavior for a given item.
    
    [CreateAssetMenu(menuName = "Items/Behaviors/Item Behavior Registry")]
    public class ItemBehaviorRegistry : ScriptableObject
    {
        [SerializeField] private ItemBehavior[] behaviors;
        
        public ItemBehavior GetBehavior(uint id)
        {
            foreach (var behavior in behaviors)
                if (behavior.ItemData.Id == id)
                    return behavior;
            
            return null;
        }
        
        public ItemBehavior GetBehavior(ItemData item)
        {
            foreach (var behavior in behaviors)
                if (behavior.ItemData == item)
                    return behavior;
            
            return null;
        }
    }
}