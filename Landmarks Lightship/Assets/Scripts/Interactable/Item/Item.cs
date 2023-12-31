using UnityEngine;


[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public ItemID id;
    public string itemName;
    public int value;
    public Sprite icon;
    public enum ItemID { None, Sword, Shield, Bow, Arrow, Potion, Coin}


}
