using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSource : InteractableObject
{
    [SerializeField][Range(1, 10)] private int numberOfCoins;


    private void Awake()
    {
        
    }
    public override void Interact()
    {
        CoinInventory.Singleton.AddCoins(numberOfCoins);
    }
}
