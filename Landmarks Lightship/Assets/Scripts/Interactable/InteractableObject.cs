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
    protected bool _inRange = false;
    private AudioManager audioManager;
    
    protected virtual void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (readyOnStart)
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
    public virtual void Select(WorldInteractor worldInteractor)
    {
        _selected = true;
        _worldInteractor = worldInteractor;
        
    }

    // Deselects the object
    public virtual void Deselect()
    {
        _selected = false;
        _worldInteractor = null;
    }
    
    public virtual bool InRange()
    {
        return _inRange;
    }

    // Interacts with the object
    public virtual void Interact()
    {
        if (_ready)
        {
            audioManager.Play(audioManager.playerInteract);
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

    protected virtual void OnInRange()
    {
        _inRange = true;
    }

    protected virtual void OnOutOfRange()
    {
        _inRange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("World Interactor"))
        {
            if (!_inRange)
            {
                OnInRange();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("World Interactor"))
        {
            if (_inRange)
            {
                OnOutOfRange();
            }
        }
    }
}
