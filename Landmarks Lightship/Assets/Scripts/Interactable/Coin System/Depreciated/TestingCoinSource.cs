using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT IS TEMPORARY AND SHOULD ONLY BE USED FOR TESTING THE COIN SYSTEM
public class TestingCoinSource : MonoBehaviour
{
    [SerializeField][Range(1, 10)] private int numberOfCoins;
    public int NumberOfCoins
    {
        get { return numberOfCoins; }
        private set { numberOfCoins = value; }
    }
}
