using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

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
    }
}
