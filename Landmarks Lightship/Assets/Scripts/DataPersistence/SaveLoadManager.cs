using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        // Create a file path using Application.persistentDataPath
        filePath = Application.persistentDataPath + "/DataPersistence";
    }

    public void SaveInventory(Item[] inventory)
    {
        // Convert the inventory array to JSON
        string json = JsonUtility.ToJson(inventory, true);

        // Write JSON data to the file
        File.WriteAllText(filePath, json);

        Debug.Log("Inventory saved to: " + filePath);
    }

    public Item[] LoadInventory()
    {
        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read JSON data from the file
            string json = File.ReadAllText(filePath);

            // Deserialize JSON data back into an array of Item objects
            return JsonUtility.FromJson<Item[]>(json);
        }
        else
        {
            Debug.LogWarning("No inventory data found.");
            return null;
        }
    }

    private void OnApplicationQuit()
    {
        // Save inventory data when the application quits
       // SaveInventory(InventoryManager.Instance.Items.ToArray());
    }
}
