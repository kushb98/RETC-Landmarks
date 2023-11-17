using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    protected override void Start()
    {
        base.Start();

        nameText.color = availableColor;
    }

    // Resets the street name and makes it available for use again
    protected override void MakeReady()
    { 
        base.MakeReady();
        
        nameText.color = availableColor;
    }

    protected override void Consume()
    {
        base.Consume();
        
        nameText.color = consumedColor;

        CoinInventory.Singleton.AddCoins(coinReward);
        RankManager.Singleton.IncreaseEXP(expReward);
    }
}
