using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinInventory : MonoBehaviour, IDataPersistence
{
    public static CoinInventory Singleton;

    [SerializeField] private CoinUI coinUI;

    private int _numCoins;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Debug.LogError("There can not be more than one instance of a singleton");
    }


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

    // Added to save coin data
    public void LoadData(GameData data)
	{
       coinUI.SetCoinDisplay(data._numCoins);
		this._numCoins = data._numCoins;
	}
    
    public void SaveData(ref GameData data)
    {
        data._numCoins = this._numCoins;
        Debug.Log("Saving coin data");
    }

}
