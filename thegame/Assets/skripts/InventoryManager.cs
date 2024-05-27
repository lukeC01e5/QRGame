using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    public InventorySlot[] inventorySlots;

    public bool AddItem(Item item)
    {
        // Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DragTheItem itemInSlot = slot.GetComponentInChildren<DragTheItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return  true;
            }


            /*
            if (itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
            */
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DragTheItem inventoryItem = newItemGo.GetComponent<DragTheItem>();
        inventoryItem.InitaliseItem(item);
    }
}
