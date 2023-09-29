using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private GameObject selectedIndicator;

    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        private set { }
    }

    public void Select()
    {
        _selected = true;
        selectedIndicator.SetActive(true);
    }

    public void Deselect()
    {
        _selected = false;
        selectedIndicator.SetActive(false);
    }

    public virtual void Interact()
    {
        Debug.LogWarning(this + " has no Interact method implemented");
    }
}
