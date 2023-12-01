using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// An interface wetween all sytems and the environment
/// </summary>
public class WorldInteractor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float interactionRange = 200;

    [Header("References")]
    [SerializeField] private CoinInventory coinInventory;
    [SerializeField] private CameraController cameraController;

    [Header("UI References")]
    [SerializeField] private GameObject interactingIndicator;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button exitInteraction;
    [SerializeField] private LayerMask interactable;

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

    // Fires a raycast to see if the player has just clicked on anything
    private void OnClick()
    {
        if (_inInteraction)
        {
            return; // TODO: Put code for what happens durring interactions here
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactable))
        {
            if (hit.transform.CompareTag("Interactable Object"))
                InitializeInteraction(hit);

            TryCoinInteraction(hit); // This is depreciated!
        }
    }

    // Initializes an object interaction, sets the current interactable object
    private void InitializeInteraction(RaycastHit hit)
    {
        interactingIndicator.SetActive(true);
        _inInteraction = true;

        _currentInteractableObject = hit.transform.GetComponent<InteractableObject>();
        
        _currentInteractableObject.Select(this);
        interactButton.onClick.AddListener(_currentInteractableObject.Interact);
        cameraController.FocusOn(_currentInteractableObject.transform);
    }

    // Clears the current interactable object
    public void ClearInteraction()
    {
        cameraController.BreakFocus();
        interactButton.onClick.RemoveAllListeners();

        if(_currentInteractableObject != null)
        {
            _currentInteractableObject.Deselect();
            _currentInteractableObject = null;
        }

        _inInteraction = false;
        interactingIndicator.SetActive(false);
    }

    // Tries to pickup or discard coins 
    // This is depreciated!
    private void TryCoinInteraction(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Coin Source"))
        {
            TestingCoinSource coinSource = hit.transform.GetComponent<TestingCoinSource>();

            coinInventory.AddCoins(coinSource.NumberOfCoins);
        }
/*
        if (hit.transform.CompareTag("Coin Remover"))
        {
            TestingCoinRemover coinRemover = hit.transform.GetComponent<TestingCoinRemover>();

            coinInventory.TryRemoveCoins(coinRemover.NumberOfCoins);
        }*/
    }
}
