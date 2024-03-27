using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int _numCoins;
    public SerializableDictionary<string, bool> itemsCollected;
    public Item roamling;
    public GameObject item;

    public ItemData itemData;

    public GameData()
    {
        this._numCoins = 1;
        itemsCollected = new SerializableDictionary<string, bool>();
        itemData = new ItemData();
       // item = new GameObject();

    }
}
