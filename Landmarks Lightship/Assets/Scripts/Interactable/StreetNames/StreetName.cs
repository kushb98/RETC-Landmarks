using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The StreetName class is an example of a class that extends from the InteractableObject class.
/// It represents a street name in the game that can be interacted with by the player.
/// 
/// The StreetName class overrides the Start, MakeReady, and Consume methods from the InteractableObject class.
/// 
/// In the Start method, it sets the color of the street name to the available color.
/// 
/// In the MakeReady method, it resets the street name and makes it available for use again by changing the color to the available color.
/// 
/// In the Consume method, it changes the color of the street name to the consumed color and rewards the player with coins and experience points.
/// </summary>
public class StreetName : InteractableObject
{
    [Header("Rewards")]
    [SerializeField] private int coinReward = 2;
    [SerializeField] private int expReward = 300;

    [Header("Settings")]
    [SerializeField] private Color availableColor = Color.yellow;
    [SerializeField] private Color consumedColor = Color.gray;

    [Header("References")]
    [SerializeField] private TextMeshPro nameText;

    /// <summary>
    /// Overrides the Start method from the InteractableObject class 
    /// so that it also sets the color of the street name to the available color.
    /// </summary>
    protected override void Start()
    {
        base.Start();

        nameText.color = availableColor;
    }

    /// <summary>
    /// Overrides the MakeReady method from the InteractableObject class 
    /// so that it also resets the street name and makes it available for use again by changing the color to the available color.
    /// </summary>
    protected override void MakeReady()
    {
        base.MakeReady();

        nameText.color = availableColor;
    }

    /// <summary>
    /// Overrides the Consume method from the InteractableObject class 
    /// so that it also changes the color of the street name to the consumed color and rewards the player with coins and experience points.
    /// </summary>
    protected override void Consume()
    {
        base.Consume();

        nameText.color = consumedColor;

        CoinInventory.Singleton.AddCoins(coinReward);
        RankManager.Singleton.IncreaseEXP(expReward);
    }
}
