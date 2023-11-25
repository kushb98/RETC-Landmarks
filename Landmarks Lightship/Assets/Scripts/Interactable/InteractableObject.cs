using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The InteractableObject class is the base class for all interactable objects in the game.
/// It provides basic functionality for interaction and can be extended to create more complex interactable objects.
/// 
/// To create a new type of interactable object, extend this class and override the necessary methods.
/// The WorldInteractor class interacts with objects of this type, and by overriding specific methods,
/// you can customize how the WorldInteractor interacts with your new class.
/// 
/// The following methods can be overridden:
/// - ReadyForInteraction: Determines whether the object is ready for interaction.
/// - Interact: Defines the interaction behavior of the object.
/// - Consume: Defines the behavior when the object is consumed.
/// - MakeReady: Defines the behavior when the object is made ready for interaction.
/// 
/// Note: If an object is selected, it will automatically be deselected when it is destroyed.
/// </summary>
public class InteractableObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool readyOnStart = true;
    [SerializeField] private string name = "New Interactable Object";

    private WorldInteractor _worldInteractor;

    private bool _selected = false;
    // Returns whether the object is selected
    public bool Selected
    {
        get { return _selected; }
        private set { }
    }

    protected bool _ready = false;


    protected virtual void Start()
    {
        if (readyOnStart)
        {
            _ready = true;
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

    /// <summary>
    /// Selects the object and assigns the WorldInteractor that selected it.
    /// </summary>
    /// <param name="worldInteractor">The WorldInteractor that selected the object.</param>
    public void Select(WorldInteractor worldInteractor)
    {
        _selected = true;
        _worldInteractor = worldInteractor;
    }

    /// <summary>
    /// Deselects the object and removes the reference to the WorldInteractor that selected it.
    /// </summary>
    public void Deselect()
    {
        _selected = false;
        _worldInteractor = null;
    }

    /// <summary>
    /// Determines whether the object is ready for interaction.
    /// Override this method to customize the readiness check.
    /// </summary>
    public virtual bool ReadyForInteraction()
    {
        return _ready;
    }

    /// <summary>
    /// Defines the interaction behavior of the object.
    /// Override this method to customize the interaction behavior.
    /// </summary>
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

    /// <summary>
    /// Defines the behavior when the object is consumed.
    /// Override this method to customize the consumption behavior.
    /// </summary>
    protected virtual void Consume()
    {
        _ready = false;
    }

    /// <summary>
    /// Defines the behavior when the object is made ready for interaction.
    /// Override this method to customize the readiness behavior.
    /// </summary>
    protected virtual void MakeReady()
    {
        _ready = true;
    }
}
