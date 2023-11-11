using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinDisplay;

    [Header("Insufficient Funds")]
    [SerializeField] private GameObject insufficientFundsWarning;
    [SerializeField] private float warningTime;

    // Sets the coin display to a number of coins
    public void SetCoinDisplay(int numCoins)
    {
        coinDisplay.text = "Coins: " + numCoins.ToString();
    }

    public void ShowInsufficientFunds()
    {
        StartCoroutine(InsufficientFundsRoutine());
    }

    private IEnumerator InsufficientFundsRoutine()
    {
        insufficientFundsWarning.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        insufficientFundsWarning.SetActive(false);
    }
}
