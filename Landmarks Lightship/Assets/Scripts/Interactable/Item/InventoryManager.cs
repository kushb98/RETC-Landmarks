using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;


public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager Instance;

    [SerializeField]
    public List<Item> Items = new List<Item>();
    //public List<Item> ShopItems = new List<Item>();

    public InventoryItemController[] InventoryItems;
    public InventoryItemController[] BoughtItems;

    public GameObject RoamlingMenu;
    public Transform ItemContent;
    public GameObject InventoryItem;
    public RoamlingController roamlingController;
    public GameObject Inventory;

    public GameObject ItemInventory;
    public Transform BoughtContent;

    public Toggle ReleaseRoamlings;

    private AudioManager audioManager;




    [SerializeField] private Item itemDataSO;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple Inventory Managers In Scene");

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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

        //change later for specifically shop items
        if (item.itemName == "Toy" || item.itemName == "Treat")
        {
            audioManager.Play(audioManager.itemBought);
        }
     
       

        
    }

    public void Remove(Item item)
    {
        List<Item> newItems = Items;
        newItems.Remove(item);
        Items = newItems;
        Debug.Log("Item Removed");

    }

    public void ClearInventory()
    {
        Items.Clear();
        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

       foreach (Transform item in BoughtContent)
        {
            Destroy(item.gameObject);
        }
      
        foreach (var item in Items)
        {
            if (item.value > 0)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);


                var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;

                obj.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item));

                if (ReleaseRoamlings.isOn)
                {
                    removeButton.gameObject.SetActive(true);
                }

            }

            // if the item value is 0, do the same for BoughtContent
            if (item.value == 0)
            {
                GameObject obj2 = Instantiate(InventoryItem, BoughtContent);
                var itemName2 = obj2.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                var itemIcon2 = obj2.transform.Find("ItemIcon").GetComponent<Image>();
                var removeButton2 = obj2.transform.Find("RemoveButton").GetComponent<Button>();

                itemName2.text = item.itemName;
                itemIcon2.sprite = item.icon;
            }
        }

        SetInventoryItems();
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

    public void EnableReleaseRoamling()
    {
        if (ReleaseRoamlings.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        //set the inventory items to the number in both item content and bought content
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        BoughtItems = BoughtContent.GetComponentsInChildren<InventoryItemController>();

        // for (int i = 0; i < Items.Count - BoughtContent.childCount; i++)
        for (int i = 0; i < Items.Count - BoughtContent.childCount; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
       
        /*if (Items.Count > 0)
        {
            for (int i = 0; i < Items.Count - BoughtContent.childCount; i++)
            {
                InventoryItems[i].AddItem(Items[i]);
            }
        }
      /*  else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                BoughtItems[i].AddItem(Items[i]);
            }
        }
     /* for (int i = 0; i < Items.Count; i++)
        {
            BoughtItems[i].AddItem(Items[i]);
        }
     */   

    }

    private void OnApplicationQuit()
    {
        ListItems();
    }


}

