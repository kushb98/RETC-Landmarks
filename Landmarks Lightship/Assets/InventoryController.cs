using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
   public Item item;
   public Roamling roamling;

    public Button RemoveButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Debug.Log("Item Removed, controller");
        Destroy(gameObject);
        
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void AddRoamling(Roamling newRoamling)
    {
        roamling = newRoamling;
        Debug.Log("Roamling added, controller");
    }
   
}
