using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractor : MonoBehaviour
{
    [SerializeField] private CoinInventory coinInventory;

    [SerializeField] private LayerMask interactable;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            TryCoinInteraction();
    }

    // Tries to pickup or discard coins
    private void TryCoinInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, interactable))
        {
            if (hit.transform.CompareTag("Coin Source"))
            {
                CoinSource coinSource = hit.transform.GetComponent<CoinSource>();

                coinInventory.AddCoins(coinSource.NumberOfCoins);
            }

            if (hit.transform.CompareTag("Coin Remover"))
            {
                CoinRemover coinRemover = hit.transform.GetComponent<CoinRemover>();

                coinInventory.TryRemoveCoins(coinRemover.NumberOfCoins);
            }
        }
    }
}
