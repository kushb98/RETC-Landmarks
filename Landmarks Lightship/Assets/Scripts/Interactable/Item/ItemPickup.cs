using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableObject
{
    public Item Item;

    public RoamlingController inv;





    protected override void Start()
    {
        base.Start();
        inv = Object.FindObjectOfType<RoamlingController>();
    }

    protected override void Consume()
    {
        if (Item.name == "Treat")
        {
            print("A treat!");
           inv.treatNum++;
            inv.UpdateInventory();
        }

        else
        {
            print("Not a treat!");
        }

        InventoryManager.Instance.Add(Item);
        Destroy(this.gameObject); // This works because OnDestroy is overridden in InteractableObject!
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
