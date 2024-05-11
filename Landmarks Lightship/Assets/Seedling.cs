using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Seedling : MonoBehaviour
{
    // Start is called before the first frame update

    public int seedlingCount = 0;

    public TextMeshProUGUI seedlingtext;

    int newFood = 0;
    int newTreat = 0;

    public RoamlingController treatfoodInv;


    void Start()
    {
        treatfoodInv = FindObjectOfType<RoamlingController>();
        SeedCountUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OpenSeedling()
    {
        if (seedlingCount > 0)
        {
            newFood = Random.Range(3, 6);

            newTreat = Random.Range(3,6);

            treatfoodInv.foodNum += newFood;

            treatfoodInv.treatNum += newTreat;
            seedlingCount --;

            treatfoodInv.UpdateInventory();

            SeedCountUpdate();

        }
    }

    public void SeedCountUpdate()
    {
        seedlingtext.text = "Seedlings: " + seedlingCount;
    }
}
