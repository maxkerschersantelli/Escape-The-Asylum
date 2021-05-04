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

    [SerializeField] private GameObject controlsSettingsMenu;
    [SerializeField] private GameObject audioSettingsMenu;
    [SerializeField] private GameObject newGameMenu;
    [SerializeField] private GameObject loadGameMenu;

    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private Button continueButton;
    [SerializeField] private SaveGameManagerSO sgm;
    [SerializeField] private GameObject testMenuOnClick;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);

        leftMenu.SetActive(true);
        leftMenuMain.SetActive(true);
        leftMenuSub.SetActive(false);

        rightMenu.SetActive(true);
        rightMenuBackgroundImage.SetActive(false);
        title.SetActive(true);
        
        audioSettingsMenu.SetActive(false);
        controlsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(false);
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);

        testMenuOnClick.SetActive(false);

        if (sgm.CurrentSaveIsNull() || sgm.GetCurrentFile().IsBeaten())
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void ContinueButtonOnClick()
    {
        leftMenu.SetActive(false);
        rightMenu.SetActive(false);
        loadingScreen.SetActive(true);
    }

    public void NewGameOnCLick()
    {
        newGameMenu.SetActive(true);
        loadGameMenu.SetActive(false);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        controlsSettingsMenu.SetActive(false);
    }

    public void LoadGameOnCLick()
    {
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(true);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        controlsSettingsMenu.SetActive(false);
    }

    public void SettingsOnClick()
    {
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(true);

        audioSettingsMenu.SetActive(false);
        controlsSettingsMenu.SetActive(true);

        leftMenuMain.SetActive(false);
        leftMenuSub.SetActive(true);
    }

    public void BackOnClick()
    {
        controlsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(false);

        leftMenuMain.SetActive(true);
        leftMenuSub.SetActive(false);

        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        title.SetActive(true);
        rightMenuBackgroundImage.SetActive(false);
    }

    public void TestOnClick()
    {
        controlsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(false);

        leftMenuMain.SetActive(true);
        leftMenuSub.SetActive(false);

        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        title.SetActive(false);
        rightMenuBackgroundImage.SetActive(false);
        testMenuOnClick.SetActive(true);
    }

    public void GraphicsSettingsOnClick()
    {
        controlsSettingsMenu.SetActive(true);
        audioSettingsMenu.SetActive(false);
    }

    public void AudioSettingsOnClick()
    {
        controlsSettingsMenu.SetActive(false);
        audioSettingsMenu.SetActive(true);
    }

    IEnumerator LoadNewScene()
    {
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(2);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }
}
