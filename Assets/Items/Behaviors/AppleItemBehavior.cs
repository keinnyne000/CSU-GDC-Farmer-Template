using Farmer.Player;
using UnityEngine;

namespace Farmer.Items.Behaviors
{
    // This is a concrete class (meaning you *can* make one), notice that it inherits from ItemBehavior
    // This class is used to define the behavior of an apple item.
    // It is a ScriptableObject, so it can be created as an asset in the Unity Editor.
    [CreateAssetMenu(menuName = "Items/Behaviors/Apple Item Behavior")]
    public class AppleItemBehavior : ItemBehavior
    {
        public override void Use(PlayerInventory inventory, int slot)
        {
            // Get the item from the inventory, decrement the quantity, and push it back into the inventory.
            (uint, int) apple = inventory.Inventory.PopItem(slot);
            apple.Item2--; 
            if (apple.Item2 > 0) inventory.Inventory.PushItem(apple.Item1, apple.Item2, slot); 

            // Could add health to the player, or throw the apple by instantiating a prefab that is a projectile.
            // For now, just log that the apple was used!
            Debug.Log("Apple used!");
        }
    }
}