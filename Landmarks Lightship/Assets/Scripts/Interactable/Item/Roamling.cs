using UnityEngine;

[CreateAssetMenu(fileName = "New Roamling", menuName = "Roamling/Create New Roamling")]
public class Roamling : ScriptableObject
{
    public RoamlingID id;
    public string roamlingName;
    public Sprite icon;
    public int hunger;
    public int happiness;

    public enum RoamlingID { None, Axolotl, Bear, Turtle }
}
