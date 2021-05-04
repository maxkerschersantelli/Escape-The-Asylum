using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private bool isInteractable;

    public void Activate()
    {
        isInteractable = true;
    }

    public void Deactivate()
    {
        isInteractable = false;
    }

    public bool IsInteractive()
    {
        return isInteractable;
    }
}
