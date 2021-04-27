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
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject winScreen;

    [SerializeField] private GameEvent loadEvent;
    [SerializeField] private SaveGameManagerSO sgm;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.SetActive(true);
        menu.SetActive(false);
        audioMenu.SetActive(false);
        controlMenu.SetActive(false);
        loadingScreen.SetActive(false);
        winScreen.SetActive(false);
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
        FileSaveData file =  sgm.GetCurrentFile().GetFileSaveData();
        file.time += Time.timeSinceLevelLoad;
        sgm.GetCurrentFile().SaveFileSaveData(file);
        loadEvent.Raise();
        loadingScreen.SetActive(true);
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

    public void winGame()
    {
        IEnumerator coroutine = endGame();
        StartCoroutine(coroutine);
    }

    private IEnumerator endGame()
    {
        winScreen.SetActive(true);
        FileSaveData file = sgm.GetCurrentFile().GetFileSaveData();
        file.time += Time.timeSinceLevelLoad;
        file.finished = true;
        sgm.GetCurrentFile().SaveFileSaveData(file);
        yield return new WaitForSeconds(2);
        winScreen.SetActive(false);
        loadEvent.Raise();
        loadingScreen.SetActive(true);
    }
}
