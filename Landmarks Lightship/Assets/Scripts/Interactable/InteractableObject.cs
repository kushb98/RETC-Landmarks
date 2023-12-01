using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basis for any interactable objects in the game
/// Provides basic functionality and allows for integration with WorldInteractor
/// </summary>
public class InteractableObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool readyOnStart = true;
    [SerializeField] private string name = "New Interactable Object";

    private WorldInteractor _worldInteractor;

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
    public void Select(WorldInteractor worldInteractor)
    {
        _selected = true;
        _worldInteractor = worldInteractor;
    }

    // Deselects the object
    public void Deselect()
    {
        _selected = false;
        _worldInteractor = null;
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

    protected void OnDestroy()
    {
        if (_selected)
        {
            _worldInteractor.ClearInteraction();
            Deselect();
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
