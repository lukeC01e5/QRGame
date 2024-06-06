using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 4;
    public GameObject inventoryItemPrefab;
    public GameObject creatureItemPrefab; // Add this line
    public InventorySlot[] inventorySlots;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 6)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item, bool isCreature = false)
    {
        // Check if item is null
        if (item == null)
        {
            Debug.Log("Item is null");
            return false;
        }

        // Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            if (slot == null)
            {
                Debug.Log("Slot " + i + " is null");
                continue;
            }

            DragTheItem itemInSlot = slot.GetComponentInChildren<DragTheItem>();
            if (itemInSlot == null)
            {
                Debug.Log("Item in slot " + i + " is null");
                continue;
            }

            if (itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            if (slot == null)
            {
                Debug.Log("Slot " + i + " is null");
                continue;
            }

            DragTheItem itemInSlot = slot.GetComponentInChildren<DragTheItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot, isCreature);
                return true;
            }
        }

        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot, bool isCreature = false)
    {
        GameObject newItemGo;
        if (isCreature)
        {
            newItemGo = Instantiate(creatureItemPrefab, slot.transform);
        }
        else
        {
            newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        }
        DragTheItem inventoryItem = newItemGo.GetComponent<DragTheItem>();
        inventoryItem.InitaliseItem(item);
    }



    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        DragTheItem itemInSlot = slot.GetComponentInChildren<DragTheItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }

            return item;
        }

        return null;
    }




}