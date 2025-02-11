using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Farmer.UI
{
    public class InventorySlotUI : MonoBehaviour, IDropHandler
    {
        [field: SerializeField] public Transform itemParent { get; private set; }
        [HideInInspector] public int slotIndex;

        public event Action<int, int> OnRequestItemMove;
        
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("dropped item on slot " + slotIndex);
            var itemData = eventData.pointerDrag.GetComponent<InventoryItemUI>();
            OnRequestItemMove?.Invoke(itemData.slotIndex, slotIndex);
        }
    }
}