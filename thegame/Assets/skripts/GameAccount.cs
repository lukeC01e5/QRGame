using UnityEngine;

[System.Serializable]
public class GameAccount
{
    public string _id;
    public string userId;
    public string username;
    public int coin;

    public void LogValues()
    {
        Debug.Log("ID: " + _id);
        Debug.Log("User ID: " + userId);
        Debug.Log("Username: " + username);
        Debug.Log("Coin: " + coin);

        // ... log other fields ...
    }

    /*
   public enum ItemType
   {
       Sword,
       Water,
       Crystal,
       Coin,
       Meat,
       Plant,
   }

   public ItemType itemType;
   public int amount;

   public Sprite GetSprite()
   {
       switch (itemType)
       {
           default:
           case ItemType.Sword: return ItemAssets.Instance.swordSprite;
           case ItemType.Water: return ItemAssets.Instance.waterSprite;
           case ItemType.Crystal: return ItemAssets.Instance.crystalSprite;
           case ItemType.Coin: return ItemAssets.Instance.coinSprite;
           case ItemType.Meat: return ItemAssets.Instance.meatSprite;
           case ItemType.Plant: return ItemAssets.Instance.plantSprite;
       }
   }
   */
}

