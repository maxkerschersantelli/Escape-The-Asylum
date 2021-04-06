using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject leftMenu;
    [SerializeField] private GameObject leftMenuMain;
    [SerializeField] private GameObject leftMenuSub;

    [SerializeField] private GameObject rightMenu;
    [SerializeField] private GameObject rightMenuBackgroundImage;

    [SerializeField] private GameObject title;

    [SerializeField] private GameObject graphicsSettingsMenu;
    [SerializeField] private GameObject audioSettingsMenu;
    [SerializeField] private GameObject newGameMenu;
    [SerializeField] private GameObject loadGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        leftMenu.SetActive(true);
        leftMenuMain.SetActive(true);
        leftMenuSub.SetActive(false);

        rightMenu.SetActive(true);
        rightMenuBackgroundImage.SetActive(false);
        title.SetActive(true);
        
        audioSettingsMenu.SetActive(false);
        graphicsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(false);
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
    }

    public void ContinueButtonOnClick()
    {
        SceneManager.LoadScene("Test");
    }

    public void NewGameOnCLick()
    {
        newGameMenu.SetActive(true);
        loadGameMenu.SetActive(false);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        graphicsSettingsMenu.SetActive(false);
    }

    public void LoadGameOnCLick()
    {
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(true);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        graphicsSettingsMenu.SetActive(false);
    }

    public void SettingsOnClick()
    {
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        graphicsSettingsMenu.SetActive(true);

        leftMenuMain.SetActive(false);
        leftMenuSub.SetActive(true);
    }

    public void BackOnClick()
    {
        graphicsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(false);

        leftMenuMain.SetActive(true);
        leftMenuSub.SetActive(false);

        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        title.SetActive(true);
        rightMenuBackgroundImage.SetActive(false);
    }

    public void GraphicsSettingsOnClick()
    {
        graphicsSettingsMenu.SetActive(true);
        audioSettingsMenu.SetActive(false);
    }

    public void AudioSettingsOnClick()
    {
        graphicsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(true);
    }
}
