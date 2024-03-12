using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    public Item item; // Reference to your item instance

    public void FeedButtonClicked()
    {
        // Increase happiness and decrease hunger when the feed button is clicked
        item.Happiness += 10;
        item.Hunger -= 5;

        // Call this method to update the UI sliders
        item.UpdateUI();
    }

    public void PlayButtonClicked()
    {
        // Increase happiness when the play button is clicked
        item.Happiness += 20;

        // Call this method to update the UI sliders
        item.UpdateUI();
    }
}
