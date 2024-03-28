using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager Instance;

    [SerializeField]
    public List<Item> Items = new List<Item>();

    public GameObject RoamlingMenu;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public RoamlingController roamlingController;
    public GameObject Inventory;

    
    [SerializeField] private Item itemDataSO;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple Inventory Managers In Scene");
    }

    private void Start()
    {
        ListItems(); // Initially list items
    }

    public void LoadData(GameData data)
    {
      /* Only needed for using one ScriptableObject for all items
      itemDataSO.Hunger = data.itemData.Hunger;
       itemDataSO.Happiness = data.itemData.Happiness;
       itemDataSO.maxHunger = data.itemData.maxHunger;
       itemDataSO.maxHappiness = data.itemData.maxHappiness;
       itemDataSO.itemName = data.itemData.itemName;
      
       itemDataSO.icon = data.itemData.icon;
       itemDataSO.value = data.itemData.value;
      */
        Items = data.itemData.Items;

    }

    public void SaveData(ref GameData data)
    {
       /* data.itemData.Hunger = itemDataSO.Hunger;
        data.itemData.Happiness = itemDataSO.Happiness;
        data.itemData.maxHunger = itemDataSO.maxHunger;
        data.itemData.maxHappiness = itemDataSO.maxHappiness;
        data.itemData.itemName = itemDataSO.itemName;
        data.itemData.icon = itemDataSO.icon;
        data.itemData.value = itemDataSO.value;
       */
        data.itemData.Items = Items;


    }



    public void Add(Item item)
    {
        Items.Add(item);
        ListItems(); // Update the inventory list when adding an item
        Debug.Log("Item Added");
    }

    public void Remove(Item item)
    {

        Items.Remove(item);             
       
        ListItems(); // Update the inventory list when removing an item
        Debug.Log("Item Removed");
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            // Add an onClick event to each instantiated item
            obj.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item));
        }
    }

    // Method to handle item click and invoke Unity events
    void OnItemClick(Item item)
    {
        // Invoke Unity events from the item
        item.onClickEvent.Invoke();

        // Update UI with the current item's hunger and happiness values
        item.UpdateUI();

        //use the update roamling stats method to update the roamling stats based off the item clicked
        roamlingController.UpdateRoamlingStats(item);

        //enable RoamlingMenu and show the hunger and happiness bars based off the roamling

        RoamlingMenu.SetActive(true);
        Inventory.SetActive(false);
    } 

}

