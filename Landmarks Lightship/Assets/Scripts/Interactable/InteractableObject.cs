using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basis for any interactable objects in the game
/// Provides basic functionality and allows for integration with WorldInteractor
/// </summary>
public class InteractableObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject selectedIndicator;

    [Header("Settings")]
    [SerializeField] private bool readyOnStart = true;
    [SerializeField] private string name = "New Interactable Object";

    private bool _selected = false;
    protected bool _ready = false;

    protected virtual void Start()
    {
        if(readyOnStart)
        {
            _ready = true;
        }
    }

    // Returns whether the object is selected
    public bool Selected
    {
        get { return _selected; }
        private set { }
    }

    // Selects the object
    public void Select()
    {
        _selected = true;
        selectedIndicator.SetActive(true);
    }

    // Deselects the object
    public void Deselect()
    {
        _selected = false;
        selectedIndicator.SetActive(false);
    }
    
    public virtual bool ReadyForInteraction()
    {
        return _ready;
    }

    // Interacts with the object
    public virtual void Interact()
    {
        if (_ready)
        {
            Consume();
        }
        else
        {
            // Give some negative feedback
        }
    }

    protected virtual void Consume()
    {
        _ready = false;
    }

    protected virtual void MakeReady()
    {
        _ready = true;
    }
}
