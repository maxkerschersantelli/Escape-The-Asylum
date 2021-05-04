using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpenButton : InteractableObject
{
    [SerializeField] private DoorController door;
    [SerializeField] private DistanceChecker distanceChecker;

    private void OnMouseDown()
    {
        if (this.IsInteractive() && !EventSystem.current.IsPointerOverGameObject() && distanceChecker.IsInRange())
        {
            door.Unlock();
            door.Open();
        }
    }
}
