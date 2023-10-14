using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRemover : InteractableObject
{
    [SerializeField][Range(1, 10)] private int numberOfCoins;

    public override void Interact()
    {
        CoinInventory.Singleton.TryRemoveCoins(numberOfCoins);
    }
}
