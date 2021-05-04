using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObjectController : MonoBehaviour
{
    private Vector3 originalPosistion;
    private Quaternion originalDirection;
    private bool isMoving;
    private bool moveForward;

    [SerializeField] Camera playerCamera;
    [SerializeField] private GameObject cameraPosition;
    [SerializeField] private DistanceChecker distanceChecker;
    [SerializeField] Camera controledCamera;
    [SerializeField] InteractableObject io;

    [SerializeField] Canvas backButton;
    [SerializeField] GameObject disableUI;

    private float startTime;
    private float currentTime;
    private float slerpValue;
    [SerializeField] float duration;

    private void Start()
    {
        isMoving = false;
        moveForward = true;
        controledCamera.enabled = false;
        backButton.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && distanceChecker.IsInRange() && !isMoving && !io.IsInteractive())
        {
            this.originalPosistion = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
            this.originalDirection = new Quaternion(playerCamera.transform.rotation.x, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w);
            playerCamera.enabled = false;
            controledCamera.enabled = true;
            controledCamera.transform.position = originalPosistion;
            controledCamera.transform.rotation = originalDirection;
            isMoving = true;
            disableUI.SetActive(false);
            currentTime = startTime = Time.time;
            slerpValue = 0;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (moveForward)
            {
                if (slerpValue >= 1)
                {
                    Debug.Log("made it");
                    isMoving = false;
                    moveForward = false;
                    io.Activate();
                    backButton.enabled = true;
                    slerpValue = 0;
                }
                else
                {
                    slerpValue = (currentTime - startTime) / duration;
                    controledCamera.transform.position = Vector3.Slerp(originalPosistion, cameraPosition.transform.position, slerpValue);
                    controledCamera.transform.rotation = Quaternion.Slerp(originalDirection, cameraPosition.transform.rotation, slerpValue);
                    currentTime += Time.deltaTime;
                }
            }
            else
            {
                if (slerpValue >= 1)
                {
                    isMoving = false;
                    moveForward = true;
                    playerCamera.enabled = true;
                    controledCamera.enabled = false;
                    disableUI.SetActive(true);
                    slerpValue = 0;
                }
                else
                {
                    slerpValue = (currentTime - startTime) / duration;
                    controledCamera.transform.position = Vector3.Slerp(cameraPosition.transform.position, originalPosistion, slerpValue);
                    controledCamera.transform.rotation = Quaternion.Slerp(cameraPosition.transform.rotation, originalDirection, slerpValue);
                    currentTime += Time.deltaTime;
                }
            }
        }
    }

    public void ExitInteractable()
    {
        isMoving = true;
        io.Deactivate();
        backButton.enabled = false;
        currentTime = startTime = Time.time;
        slerpValue = 0;
    }
}
