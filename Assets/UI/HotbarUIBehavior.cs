using Farmer.Items;
using Farmer.Player;
using UnityEngine;

namespace Farmer.UI
{
    public class HotbarUIBehavior : MonoBehaviour
    {
        [SerializeField] Transform hotbarSlotParent;
        [SerializeField] GameObject hotbarSlotPrefab;
        [SerializeField] GameObject hotbarItemPrefab;
        
        [Header("References")]
        [SerializeField] PlayerInventory playerInventory;
        [SerializeField] ItemRegistry itemRegistry;
        
        InventorySlotUI[] slotUis;
        
        private void Start()
        {
            playerInventory.Inventory.OnUpdated += UpdateUI;
            playerInventory.OnHotbarIndexChanged += OnHotbarIndexChanged;
            
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
            playerInventory.OnHotbarIndexChanged -= OnHotbarIndexChanged;
        }
        
        void OnHotbarIndexChanged(int index)
        {
            for(int i = 0; i < slotUis.Length; i++)
            {
                slotUis[i].Highlight(i == index);
            }
        }
        
        void OnRequestItemMove(int fromSlot, int toSlot)
        {
            playerInventory.TryMoveItem(fromSlot, toSlot);
        }

        void RefreshItems()
        {
            for(int i = 0; i < playerInventory.HotbarCapacity; i++)
            {
                var item = playerInventory.Inventory.PeekItem(i);
                if (item.Item1 == 0)
                    continue;
                
                var itemData = itemRegistry.GetItem(item.Item1);
                var slot = slotUis[i];
                var itemUi = Instantiate(hotbarItemPrefab, slot.itemParent).GetComponent<InventoryItemUI>();
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
            
            slotUis = new InventorySlotUI[playerInventory.HotbarCapacity];

            for(int i = 0; i < playerInventory.HotbarCapacity; i++)
            {
                var slot = Instantiate(hotbarSlotPrefab, hotbarSlotParent).GetComponent<InventorySlotUI>();
                slotUis[i] = slot;
                slot.slotIndex = i;      
                slot.OnRequestItemMove += OnRequestItemMove;
            }
        }
    }
}