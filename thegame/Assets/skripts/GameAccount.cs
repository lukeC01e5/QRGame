using UnityEngine;

[System.Serializable]
public class GameAccount
{
    public string _id;
    public int adminFlag;
    public string username;
    public int gold;


    public enum ItemType
    {
        Sword,
        HeathPotion,
        ManaPotion,
        Coin,
        MedKit,
        Meat,
        Plant,
    }

    public ItemType itemType;
    public int amount;
}

