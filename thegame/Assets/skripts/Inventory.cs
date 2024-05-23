using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<GameAccount> itemList;

    public Inventory()
    {
        itemList = new List<GameAccount>();

        AddItem(new GameAccount { itemType = GameAccount.ItemType.Sword, amount = 1 });
        AddItem(new GameAccount { itemType = GameAccount.ItemType.Plant, amount = 1 });
        AddItem(new GameAccount { itemType = GameAccount.ItemType.Coin, amount = 1 });
        Debug.Log("Inventory created with " + itemList.Count + " items");
    }

    public void AddItem(GameAccount item)
    {
        if (item == null)
        {
            Debug.LogError("Trying to add a null item to the inventory");
            return;
        }
        itemList.Add(item);
        Debug.Log("Added item to inventory: " + item.itemType);
    }

    public List<GameAccount> GetItemList()
    {
        if (itemList == null)
        {
            Debug.LogError("Item list is null");
            return new List<GameAccount>();
        }
        return itemList;
    }
}
