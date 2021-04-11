using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject disableUI;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.SetActive(true);
        menu.SetActive(false);
        audioMenu.SetActive(false);
        controlMenu.SetActive(false);
    }

    public void menuButtonClick()
    {
        menuButton.SetActive(false);
        menu.SetActive(true);
        audioMenu.SetActive(false);
        controlMenu.SetActive(false);

        if (disableUI != null)
        {
            disableUI.GetComponent<Canvas>().enabled = false;
        }
    }

    public void backButtonClick()
    {
        menuButton.SetActive(true);
        menu.SetActive(false);
        audioMenu.SetActive(false);
        controlMenu.SetActive(false);

        if (disableUI != null)
        {
            disableUI.GetComponent<Canvas>().enabled = true;
        }
    }

    public void exitButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void graphicsSettingsButtonClick()
    {
        menuButton.SetActive(false);
        menu.SetActive(false);
        audioMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void audioSettingsButtonClick()
    {
        menuButton.SetActive(false);
        menu.SetActive(false);
        audioMenu.SetActive(true);
        controlMenu.SetActive(false);
    }
}
