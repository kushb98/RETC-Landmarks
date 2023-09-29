using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractor : MonoBehaviour
{
    [Header("Interaction System")]
    [SerializeField] private GameObject interactingIndicator;
    [SerializeField] private LayerMask interactable;
    [SerializeField] private KeyCode clearInteractKey = KeyCode.Escape;

    [Header("References")]
    [SerializeField] private CoinInventory coinInventory;

    private InteractableObject _currentInteractableObject;
    private bool _inInteraction;

    void Update()
    {
        if (Input.GetKeyDown(clearInteractKey))
            ClearInteraction();
                
        if (Input.GetKeyUp(KeyCode.Mouse0))
            OnClick();
    }

    // Clears the current interactable object
    private void ClearInteraction()
    {
        _currentInteractableObject.Deselect();
        _currentInteractableObject = null;

        _inInteraction = false;
        interactingIndicator.SetActive(false);
    }

    // What heppens when the player clicks on the screen
    private void OnClick()
    {
        if (_inInteraction)
            return; // TODO: Put code for what happens durring interactions here

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 500, interactable))
        {
            TryObjectInteraction(hit);
            TryCoinInteraction(hit);
        }
    }

    // Tries to interact with an interactable object
    private void TryObjectInteraction(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Interactable Object"))
        {
            interactingIndicator.SetActive(true);

            _inInteraction = true;
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
