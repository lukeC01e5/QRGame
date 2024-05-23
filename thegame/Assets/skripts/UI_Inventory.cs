using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    public void SetInventory(Inventory inventory)
    {
        Debug.Log("Setting inventory: " + inventory);
        this.inventory = inventory;
        Debug.Log("Number of items in inventory: " + inventory.GetItemList().Count);
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        Debug.Log("Refreshing inventory items for inventory: " + inventory);
        int x = 0;
        int y = 0;
        foreach (GameAccount item in inventory.GetItemList())
        {
            CreateItemSlot(x, y);
            x++;
            if (x > 8) // If x > 4, start a new row
            {
                x = 0;
                y++;
            }
        }
    }

    private void CreateItemSlot(int x, int y)
    {
        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
        Debug.Log("Item slot rect transform: " + itemSlotRectTransform);
        itemSlotRectTransform.gameObject.SetActive(true);
        itemSlotRectTransform.anchoredPosition = new Vector2(x * 35f, y * 35f);
    }
}