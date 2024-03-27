using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

[System.Serializable]
public class Item : ScriptableObject, IDataPersistence


{
   [SerializeField] private string id;

    [ContextMenu("Generate GUID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool collected = false;
    private GameObject item;

  //  public ItemID id;
    public string itemName;
    public int value;
    public Sprite icon;
    public int Hunger;
    public int maxHunger;
    public int Happiness;
    public int maxHappiness;
    public GameObject inventoryManager;

    [SerializeField]
    public enum ItemID { None, Axolotl, Bear, Turtle }

    // Convert the item to JSON
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
   

    // Unity event to be invoked when the item is clicked
    [SerializeField]
    public UnityEvent onClickEvent = new UnityEvent();


    // Call this method to update UI with the current item's hunger and happiness values
    public void UpdateUI()
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateUI(this);
        }
    }

    public void LoadData(GameData data)
    {
      // item = data.item;
     //  Debug.Log("Test: Loading item data, Item");

       
     
    }

    public void SaveData(ref GameData data)
    {
        //save using application.persistentdatapath
        Application.persistentDataPath.ToString();
        Debug.Log("Test: Saving item data, Item");
        
    }    
}
