using Farmer.Player;
using UnityEngine;

namespace Farmer.Items.Behaviors
{
    // This is an abstract class (meaning you can't *make* one)
    // It is used as a base class for all item behaviors to standardize the Use method.
    public abstract class ItemBehavior : ScriptableObject
    {
        [field: SerializeField] public ItemData ItemData { get; private set; }
        public abstract void Use(PlayerInventory inventory, int slot);
    }
}