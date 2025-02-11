
using UnityEngine;

namespace Farmer.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
    public class ItemData : ScriptableObject
    {
        public uint Id => id;
        public Sprite Icon => icon;

        [SerializeField] Sprite icon;
        [SerializeField] uint id;

        [ContextMenu("Generate Random ID")]
        private void GenerateRandomId()
        {
            id = (uint)Random.Range(0, int.MaxValue);
            Debug.Log("Generated Random ID: " + id);
        }
    }
}