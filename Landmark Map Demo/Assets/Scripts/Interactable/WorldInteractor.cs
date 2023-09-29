using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractor : MonoBehaviour
{
    [SerializeField] private CoinInventory coinInventory;

    [SerializeField] private LayerMask interactable;

    private InteractableObject _currentInteractableObject;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            OnClick();
    }

    private void OnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 500, interactable))
        {
            TryObjectInteraction(hit);
            TryCoinInteraction(hit);
        }
    }

    private void TryObjectInteraction(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Interactable Object"))
        {
            if (_currentInteractableObject != null)
                _currentInteractableObject.Deselect();

            _currentInteractableObject = hit.transform.GetComponent<InteractableObject>();

            _currentInteractableObject.Select();
        }
    }

    // Tries to pickup or discard coins
    private void TryCoinInteraction(RaycastHit hit)
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
