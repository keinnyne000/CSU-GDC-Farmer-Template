using Farmer.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Farmer.UI
{
    public class InventoryItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [HideInInspector] public Transform parentToReturnTo = null;
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text qtyText;
        [HideInInspector] public int slotIndex;
        
        public void SetItem(ItemData data, int qty)
        {
            image.sprite = data.Sprite;
            image.enabled = true;
            qtyText.text = qty.ToString();
            qtyText.raycastTarget = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            image.raycastTarget = false;
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.root);
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            image.raycastTarget = true;
            transform.SetParent(parentToReturnTo);
        }            

    }
}