using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldInteractor : MonoBehaviour
{
    [Header("Interaction System")]
    [SerializeField] private GameObject interactingIndicator;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button exitInteraction;
    [SerializeField] private LayerMask interactable;

    [Header("References")]
    [SerializeField] private CoinInventory coinInventory;

    private InteractableObject _currentInteractableObject;
    private bool _inInteraction;

    private void Start()
    {
        exitInteraction.onClick.AddListener(ClearInteraction);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            OnClick();
    }

    // What heppens when the player clicks on the screen
    private void OnClick()
    {
        if (_inInteraction)
            return; // TODO: Put code for what happens durring interactions here

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 500, interactable))
        {
            if (hit.transform.CompareTag("Interactable Object"))
                InitializeInteraction(hit);

            TryCoinInteraction(hit);
        }
    }

    // Initializes an object interaction, sets the current interactable object
    private void InitializeInteraction(RaycastHit hit)
    {
        interactingIndicator.SetActive(true);
        _inInteraction = true;

        _currentInteractableObject = hit.transform.GetComponent<InteractableObject>();
        _currentInteractableObject.Select();

        interactButton.onClick.AddListener(_currentInteractableObject.Interact);
    }

    // Clears the current interactable object
    private void ClearInteraction()
    {
        interactButton.onClick.RemoveAllListeners();

        _currentInteractableObject.Deselect();
        _currentInteractableObject = null;

        _inInteraction = false;
        interactingIndicator.SetActive(false);
    }

    // Tries to pickup or discard coins 
    private void TryCoinInteraction(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Coin Source"))
        {
            TestingCoinSource coinSource = hit.transform.GetComponent<TestingCoinSource>();

            coinInventory.AddCoins(coinSource.NumberOfCoins);
        }

        if (hit.transform.CompareTag("Coin Remover"))
        {
            TestingCoinRemover coinRemover = hit.transform.GetComponent<TestingCoinRemover>();

            coinInventory.TryRemoveCoins(coinRemover.NumberOfCoins);
        }
    }
}
