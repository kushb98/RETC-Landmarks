using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableObject
{
    public Item Item;
    public Roamling Roamling;


    protected override void Consume()
    {
        if (Item != null)
        {
            InventoryManager.Instance.Add(Item);
        }
        else
        {
            RoamlingManager.Instance.Add(Roamling);
        }
        
       // RoamlingManager.Instance.Add(Roamling);
        Destroy(gameObject); // This works because OnDestroy is overridden in InteractableObject!

    }






    /*
    Old Code :)
    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);

    }
    private void OnMouseDown()
    {
        Pickup();
    }
    */
}
