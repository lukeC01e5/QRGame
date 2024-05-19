
/*
 remember that Item is now GameAccount 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<GameAccount> itemList;

    public Inventory()
    {
        itemList = new List<GameAccount>();
        
        AddItem(new GameAccount { itemType = GameAccount.ItemType.Sword, amount = 1});
        AddItem(new GameAccount { itemType = GameAccount.ItemType.Plant, amount = 1 });
        AddItem(new GameAccount { itemType = GameAccount.ItemType.Meat, amount = 1 });
        Debug.Log(itemList.Count);

    }

    public void AddItem(GameAccount item)
    {
        itemList.Add(item);
    }

    public List<GameAccount> GetItemList()
    {
        return itemList;
    }

}
