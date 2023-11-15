using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private GameObject selectedIndicator;
    private bool _selected;

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

    // Interacts with the object
    public virtual void Interact()
    {
        Debug.LogWarning(this + " has no Interact method implemented");
    }
}
