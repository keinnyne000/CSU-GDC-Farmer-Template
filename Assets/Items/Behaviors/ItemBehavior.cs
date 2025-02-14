using Farmer.Player;
using UnityEngine;

namespace Farmer.Items.Behaviors
{
    public abstract class ItemBehavior : ScriptableObject
    {
        [field: SerializeField] protected ItemData ItemData { get; private set; }
        public abstract void Use(PlayerInventory inventory, int slot);
    }
}