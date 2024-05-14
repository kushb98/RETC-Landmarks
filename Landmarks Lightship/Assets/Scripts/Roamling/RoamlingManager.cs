using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

public class RoamlingManager : MonoBehaviour, IDataPersistence
{
    public static RoamlingManager Instance;
    
    [SerializeField]
    public List<Roamling> Roamlings = new List<Roamling>();
    //public List<Item> ShopItems = new List<Item>();

    
    public InventoryController[] InventoryRoamlings;
    

    public GameObject RoamlingMenu;
    public Transform RoamlingContent;
    public GameObject InventoryRoamling;
    public RoamlingController roamlingController;
    public GameObject Inventory;

    //public Transform BoughtContent;

    public Toggle ReleaseRoamlings;

    private AudioManager audioManager;


   // [SerializeField] private Item itemDataSO;
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
      //  ListRoamlings(); // Initially list items
    }

    public void LoadData(GameData data)
    {
        Roamlings = data.roamlingData.Roamlings;
    }

    public void SaveData(ref GameData data)
    {
        data.roamlingData.Roamlings = Roamlings;
    }

    public void Add(Roamling roamling)
    {
        Roamlings.Add(roamling);
        ListRoamlings(); // Update the inventory list when adding an item
        Debug.Log("Roamling Added");
        

        /*
        if (item.itemName == "Toy" || item.itemName == "Treat")
        {
            audioManager.Play(audioManager.itemBought);
        }
        */
    }

  /*  public void Remove(Item item)
    {
        List<Item> newItems = Items;
        newItems.Remove(item);
        Items = newItems;
        Debug.Log("Item Removed");
    }
  */
    public void ClearInventory()
    {
        Roamlings.Clear();
        ListRoamlings();
    }

    public void ListRoamlings()
    {


        foreach (Transform roamling in RoamlingContent)
        {         
            Destroy(roamling.gameObject);    
            //remove all destroyed roamling objects from InventoryRoamlings
           // InventoryRoamlings = RoamlingContent.GetComponentsInChildren<InventoryController>();
       

          

        }


        foreach (var roamling in Roamlings)
        {
           // if (roamling.value > 0)
            {
                GameObject obj = Instantiate(InventoryRoamling, RoamlingContent);


                var roamlingName = obj.transform.Find("RoamlingName").GetComponent<TextMeshProUGUI>();
                var roamlingIcon = obj.transform.Find("RoamlingIcon").GetComponent<Image>();
                var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

                roamlingName.text = roamling.roamlingName;
                roamlingIcon.sprite = roamling.roamlingIcon;

                obj.GetComponent<Button>().onClick.AddListener(() => OnRoamlingClick(roamling));

                if (ReleaseRoamlings.isOn)
                {
                    removeButton.gameObject.SetActive(true);
                }
            }
        }
        
        SetInventoryRoamlings();
        Debug.Log("ListRoamlings");
    }

    // Method to handle item click and invoke Unity events
    void OnRoamlingClick(Roamling roamling)
    {

        // Invoke Unity events from the item
        roamling.onClickEvent.Invoke();

        // Update UI with the current item's hunger and happiness values
        roamling.UpdateRoamlingUI();

        //use the update roamling stats method to update the roamling stats based off the item clicked
        roamlingController.UpdateRoamlingStats(roamling);

        //enable RoamlingMenu and show the hunger and happiness bars based off the roamling

        RoamlingMenu.SetActive(true);
        Inventory.SetActive(false);
    }

    public void EnableReleaseRoamling()
    {
        if (ReleaseRoamlings.isOn)
        {
            foreach (Transform item in RoamlingContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in RoamlingContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryRoamlings()
    {
      
        InventoryRoamlings = RoamlingContent.GetComponentsInChildren<InventoryController>();    
        {
            // for (int i = 0; i < Roamlings.Count - RoamlingContent.childCount; i++)
            for (int i = 0; i < Roamlings.Count; i++)
            {
                InventoryRoamlings[i].AddRoamling(Roamlings[i]);
                
            }
        }

        for (int i = Roamlings.Count; i < RoamlingContent.childCount; i++)
        {
            Destroy(RoamlingContent.GetChild(i).gameObject);
        }

        //Roamlings.Remove(Roamlings[i]);
        // 

        /*if (Roamlings.Count != RoamlingContent.childCount)
        {
            //subtract objects from the Roamling content until it matches the Roamling list
            for (int i = 0; i > RoamlingContent.childCount - Roamlings.Count; i++)
            {
                Destroy(RoamlingContent.GetChild(i).gameObject);
            }
        }
        */

        Debug.Log("SetInventoryRoamling");
    }

    private void OnApplicationQuit()
    {
        ListRoamlings();
    }
}
