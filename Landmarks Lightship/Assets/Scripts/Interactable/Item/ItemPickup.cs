using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableObject
{
    public Item Item;

 
    protected override void Consume()
    {
        InventoryManager.Instance.Add(Item);

        Deselect();

        Destroy(gameObject);

        //base.Consume();
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
