using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    // Start is called before the first frame update

    public int seedlingCount = 0;

    int foodtracker = 0;

    int newFood = 0;


    void Start()
    {
        
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


            foodtracker += newFood;

            print(foodtracker);

            seedlingCount --;

        }
    }
}
