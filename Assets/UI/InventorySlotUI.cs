using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Farmer.UI
{
    // This class is used to represent a single slot in the player's inventory.
    public class InventorySlotUI : MonoBehaviour, IDropHandler
    {
        [field: SerializeField] public Transform itemParent { get; private set; }
        [SerializeField] private GameObject highlight;
        [HideInInspector] public int slotIndex;
        
        // This event broadcasts that the player wants to move an item here
        public event Action<int, int> OnRequestItemMove;
        
        public void OnDrop(PointerEventData eventData)
        {
            var itemData = eventData.pointerDrag.GetComponent<InventoryItemUI>();
            OnRequestItemMove?.Invoke(itemData.slotIndex, slotIndex);
        }
        
        public void Highlight(bool value)
        {
            highlight.SetActive(value);
        }
    }
}