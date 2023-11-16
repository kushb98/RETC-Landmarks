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
    [SerializeField] private SpriteRenderer selectedImage;

    public override void Interact()
    {
        if(_ready)
            Consume();
        else
        {
            // Give some negative feedback
        }
    }

    // Resets the street name and makes it available for use again
    private void MakeReady()
    {
        _ready = true;

        nameText.color = availableColor;
        selectedImage.color = availableColor;
    }

    private void Consume()
    {
        _ready = false;

        nameText.color = consumedColor;
        selectedImage.color = consumedColor;

        CoinInventory.Singleton.AddCoins(coinReward);
        RankManager.Singleton.IncreaseEXP(expReward);
        // add EXP reward
    }
}
