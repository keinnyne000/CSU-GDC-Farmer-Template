using System;
using Farmer.Items;
using Farmer.Player;
using UnityEngine;

namespace Farmer.UI
{
    public class PlayerInventoryUIBehavior : MonoBehaviour
    {
        [Header("Slots")]
        [SerializeField] Transform inventorySlotParent;
        [SerializeField] GameObject inventorySlotPrefab;
        
        [Header("Items")]
        [SerializeField] GameObject inventoryItemPrefab;
        
        [Header("References")]
        [SerializeField] PlayerInventory playerInventory;
        [SerializeField] ItemRegistry itemRegistry;

        InventorySlotUI[] slotUis;
        
        private void Start()
        {
            playerInventory.Inventory.OnUpdated += UpdateUI;
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            RefreshSlots();
            RefreshItems();
        }

        private void OnDestroy()
        {
            playerInventory.Inventory.OnUpdated -= UpdateUI;
        }
        
        void OnRequestItemMove(int fromSlot, int toSlot)
        {
            playerInventory.TryMoveItem(fromSlot, toSlot);
        }

        void RefreshItems()
        {
            for(int i = 0; i < playerInventory.Capacity; i++)
            {
                var item = playerInventory.Inventory.PeekItem(i);
                if (item.Item1 == 0)
                    continue;
                
                var itemData = itemRegistry.GetItem(item.Item1);
                var slot = slotUis[i];
                var itemUi = Instantiate(inventoryItemPrefab, slot.itemParent).GetComponent<InventoryItemUI>();
                itemUi.SetItem(itemData, item.Item2);
                itemUi.slotIndex = i;
            }
        }

        void RefreshSlots()
        {
            if (slotUis != null)
            {
                for(int i = slotUis.Length - 1; i >= 0; i--)
                {
                    if (slotUis[i] == null)
                        continue;
                    slotUis[i].OnRequestItemMove -= OnRequestItemMove;
                    Destroy(slotUis[i].gameObject);
                }
            }
            
            slotUis = new InventorySlotUI[playerInventory.Capacity];

            for(int i = 0; i < playerInventory.Capacity; i++)
            {
                var slot = Instantiate(inventorySlotPrefab, inventorySlotParent).GetComponent<InventorySlotUI>();
                slotUis[i] = slot;
                slot.slotIndex = i;      
                slot.OnRequestItemMove += OnRequestItemMove;
            }
        }
    }
}