
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{ 

    // Drag and drop
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragTheItem dragTheItem = dropped.GetComponent<DragTheItem>();
            dragTheItem.parentAfterDrag = transform;
        }

    }
}
