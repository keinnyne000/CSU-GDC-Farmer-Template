
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Farmer.Items
{
    // This class is a ScriptableObject, so it can be created as an asset in the Unity Editor.
    [CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string ItemName => itemName;
        public uint Id => id;
        public Sprite Sprite => sprite;
        public TileBase Tile => tile;
        public ItemType ItemType => itemType;
        public bool Stackable => stackable;
        

        [SerializeField] string itemName;
        [SerializeField] TileBase tile;
        [SerializeField] Sprite sprite;
        [SerializeField] uint id;
        [SerializeField] ItemType itemType;
        [SerializeField] bool stackable;
        
        [ContextMenu("Generate Random ID")]
        private void GenerateRandomId()
        {
            id = (uint)Random.Range(0, int.MaxValue);
            Debug.Log("Generated Random ID: " + id);
        }
    }

    public enum ItemType
    {
        BuildingBlock,
        Tool,
        Consumable,
        Weapon,
        Misc,
    }

}