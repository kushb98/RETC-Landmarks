using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinInventory : MonoBehaviour
{
    [SerializeField] private CoinUI coinUI;

    private int _numCoins;

    // Adds a certain number of coins
    public void AddCoins(int numToAdd)
    {
        _numCoins += numToAdd;
        coinUI.SetCoinDisplay(_numCoins);
    }

    // Try to remove a number of coins. Returns true if coins were succesfully removed.
    public bool TryRemoveCoins(int numToRemove) 
    {
        if (DoesHaveCoins(numToRemove))
        {
            _numCoins -= numToRemove;
            coinUI.SetCoinDisplay(_numCoins);

            return true;
        }

        coinUI.ShowInsufficientFunds();

        return false;
    }

    // Checks if the player has a certain number of coins 
    private bool DoesHaveCoins(int numToCheck)
    {
        return _numCoins >= numToCheck;
    }
}
