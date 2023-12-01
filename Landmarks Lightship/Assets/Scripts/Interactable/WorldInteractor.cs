using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The WorldInteractor class is a mediator between the player and the game environment.
/// It provides functionality to interact with objects in the game world that are derived from the InteractableObject class.
/// </summary>
public class WorldInteractor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float interactionRange = 200;

    [Header("References")]
    [SerializeField] CameraController cameraController;

    [Header("UI References")]
    [SerializeField] GameObject interactingIndicator;
    [SerializeField] Button interactButton;
    [SerializeField] Button exitInteraction;
    [SerializeField] LayerMask interactable;

    InteractableObject _currentInteractableObject;
    bool _inInteraction;

    private void Start()
    {
        exitInteraction.onClick.AddListener(ClearInteraction);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            OnClick();
    }

    /// <summary>
    /// Fires a raycast to check if the player has clicked on an InteractableObject.
    /// </summary>
    private void OnClick()
    {
        if (_inInteraction)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactable))
        {
            if (hit.transform.CompareTag("Interactable Object"))
                InitializeInteraction(hit);
        }
    }

    /// <summary>
    /// Initializes an interaction with an InteractableObject.
    /// </summary>
    /// <param name="hit">The RaycastHit object containing information about the clicked InteractableObject.</param>
    private void InitializeInteraction(RaycastHit hit)
    {
        interactingIndicator.SetActive(true);
        _inInteraction = true;

        _currentInteractableObject = hit.transform.GetComponent<InteractableObject>();

        _currentInteractableObject.Select(this);
        interactButton.onClick.AddListener(_currentInteractableObject.Interact);
        cameraController.FocusOn(_currentInteractableObject.transform);
    }

    /// <summary>
    /// Clears the current interaction.
    /// </summary>
    public void ClearInteraction()
    {
        cameraController.BreakFocus();
        interactButton.onClick.RemoveAllListeners();

        if (_currentInteractableObject != null)
        {
            _currentInteractableObject.Deselect();
            _currentInteractableObject = null;
        }

        _inInteraction = false;
        interactingIndicator.SetActive(false);
    }
}
