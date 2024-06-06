using UnityEngine;

[System.Serializable]
public class GameAccount
{
    public string[] creatures; // Add this line

    public string _id;
    public string username;
    public int coin;
    public int meat;
    public int plant;
    public int crystal;
    public int water;



    public void LogValues()
    {
        Debug.Log("ID: " + _id);
        Debug.Log("Username: " + username);
        Debug.Log("Coin: " + coin);
        Debug.Log("Meat: " + meat);
        Debug.Log("Plant: " + plant);
        Debug.Log("Crystal: " + crystal);
        Debug.Log("Water: " + water);

        // ... log other fields ...
    }
}

