using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject leftMenu;
    [SerializeField] private GameObject leftMenuSub;
    [SerializeField] private GameObject rightMenu;
    [SerializeField] private GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        leftMenu.SetActive(true);
        rightMenu.SetActive(false);
        title.SetActive(true);
        leftMenuSub.SetActive(false);
    }

    public void SwitchToLeftMenu()
    {
        rightMenu.SetActive(false);
        title.SetActive(true);
        leftMenuSub.SetActive(false);
        leftMenu.SetActive(true);
    }

    public void NewGameOnCLick()
    {
        SceneManager.LoadScene("Test");
    }

    public void LoadGameOnCLick()
    {
        rightMenu.SetActive(true);
        title.SetActive(false);
        leftMenu.SetActive(false);
    }

    public void SettingsOnClick()
    {
        rightMenu.SetActive(true);
        title.SetActive(false);
        leftMenu.SetActive(false);
        leftMenuSub.SetActive(true);
    }

    public void BackOnClick()
    {
        SwitchToLeftMenu();
    }
}
