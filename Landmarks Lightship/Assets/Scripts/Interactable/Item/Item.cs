using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemID id;
    public string itemName;
    public int value;
    public Sprite icon;
    public int Hunger;
    public int maxHunger;
    public int Happiness;
    public int maxHappiness;


    public enum ItemID { None, Axolotl, Bear, Turtle }

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
}
