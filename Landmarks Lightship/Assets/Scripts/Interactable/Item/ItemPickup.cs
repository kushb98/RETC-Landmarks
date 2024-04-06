using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableObject
{
    public Item Item;
  


    protected override void Consume()
    {
        InventoryManager.Instance.Add(Item);
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
