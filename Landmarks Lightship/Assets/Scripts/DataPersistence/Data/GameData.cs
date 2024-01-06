using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int _numCoins;
    public Dictionary<string, bool> itemsCollected;

    public GameData()
    {
        this._numCoins = 1;
        itemsCollected = new Dictionary<string, bool>();
    }
}
