using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int _numCoins;
    //public Item roamling;
    public GameObject roamling;
    public GameObject item;


    public ItemData itemData;
    public RoamlingData roamlingData;

    public GameData()
    {
        this._numCoins = 1;
        itemData = new ItemData();
        roamlingData = new RoamlingData();
    }
}
