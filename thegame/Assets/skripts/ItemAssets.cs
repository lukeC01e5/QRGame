using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }
    public Sprite swordSprite;
    public Sprite waterSprite;
    public Sprite plantSprite;
    public Sprite coinSprite;
    public Sprite crystalSprite;
    public Sprite meatSprite;

}
