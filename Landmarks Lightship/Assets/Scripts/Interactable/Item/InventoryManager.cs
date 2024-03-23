using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public GameObject RoamlingMenu;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public RoamlingController roamlingController;
    public GameObject Inventory;

    // Dictionary to map item names to roamling objects
    public Dictionary<string, Item> roamlingDictionary = new Dictionary<string, Item>();


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
        // Implement data loading logic
    }

    public void SaveData(ref GameData data)
    {
        // Implement data saving logic
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ListItems(); // Update the inventory list when adding an item
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems(); // Update the inventory list when removing an item
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

        // Fetch the corresponding roamling from the dictionary based on the item name
        if (roamlingDictionary.ContainsKey(item.itemName))
        {
            Item selectedRoamling = roamlingDictionary[item.itemName];
            roamlingController.UpdateRoamlingStats(selectedRoamling);
        }
        else
        {
            //Debug.LogError("Roamling not found for item: " + item.itemName);
            return;
        }

        Debug.Log($"Item {item.itemName} clicked");

    }
}

