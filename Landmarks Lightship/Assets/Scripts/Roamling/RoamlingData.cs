using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RoamlingData 
{
    public string itemName;
    public int value;
    public Sprite icon;
    public int Hunger;
    public int maxHunger;
    public int Happiness;
    public int maxHappiness;
    public List<Roamling> Roamlings = new List<Roamling>();


   
    public RoamlingData()
    {
        // this.itemName = "";
        // this.value = 0;
        // this.icon = null;
        this.Hunger = 20;
        this.maxHunger = 100;
        this.Happiness = 20;
        this.maxHappiness = 100;
        //current items inside the list
        Roamlings = new List<Roamling>();
    }
}
