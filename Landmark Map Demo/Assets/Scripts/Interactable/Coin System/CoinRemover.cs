using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRemover : MonoBehaviour
{
    [SerializeField][Range(1, 10)] private int numberOfCoins;
    public int NumberOfCoins
    {
        get { return numberOfCoins; }
        private set { numberOfCoins = value; }
    }
}
