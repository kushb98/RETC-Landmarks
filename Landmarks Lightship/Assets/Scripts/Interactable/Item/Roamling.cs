using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Roamling", menuName = "Roamling/Create New Roamling")]
public class Roamling : ScriptableObject
{
    [SerializeField] private string id;

    [ContextMenu("Generate GUID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool collected = false;
    private GameObject roamling;

    //  public ItemID id;
    public string roamlingName;
    public int value;
    public Sprite roamlingIcon;
    public int Hunger;
    public int maxHunger;
    public int Happiness;
    public int maxHappiness;
    public GameObject RoamlingManager;

    [SerializeField]
    public enum ItemID { None, Axolotl, Bear, Turtle }

    // Convert the item to JSON
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    [SerializeField]
    public UnityEvent onClickEvent = new UnityEvent();

    public void UpdateRoamlingUI()
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateUI(this);
        }
    }
}
