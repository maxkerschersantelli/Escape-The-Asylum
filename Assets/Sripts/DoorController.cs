using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorController : MonoBehaviour
{
    private Animator _doorAnim;
    [SerializeField] private bool isLocked;
    [SerializeField] private DistanceChecker distanceChecker;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (!isLocked && !EventSystem.current.IsPointerOverGameObject() && distanceChecker.IsInRange())
        {
            _doorAnim.SetBool("isOpening", !_doorAnim.GetBool("isOpening"));
        }
    }

    public bool IsLocked()
    {
        return isLocked;
    }

    public void Unlock()
    {
        this.isLocked = false;
    }

    public bool IsOpen()
    {
        return _doorAnim.GetBool("isOpening");
    }

    public void Open()
    {
        if (!isLocked)
        {
            _doorAnim.SetBool("isOpening", true);
        }
    }

    public void Close()
    {
        if (!isLocked)
        {
            _doorAnim.SetBool("isOpening", false);
        }
    }
}
