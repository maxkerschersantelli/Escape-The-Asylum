using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameMenuController : MonoBehaviour
{
    [SerializeField] Button save0;
    [SerializeField] Button save1;
    [SerializeField] Button save2;
    [SerializeField] Text save0Text;
    [SerializeField] Text save1Text;
    [SerializeField] Text save2Text;

    [SerializeField] Button newGame;

    [SerializeField] GameObject overWrite;

    [SerializeField] SaveGameManagerSO sgm;
    [SerializeField] GameEvent newSceneEvent;

    private int selectedIndex;
    // Start is called before the first frame update
    void OnEnable()
    {
        UnSelectAllSaves();
    }

    private void UnSelectAllSaves()
    {
        selectedIndex = -1;
        save0.interactable = true;
        save1.interactable = true;
        save2.interactable = true;
        newGame.interactable = false;
        overWrite.SetActive(false);
    }

    public void OnSaveClick(int index)
    {
        this.UnSelectAllSaves();
        this.selectedIndex = index;
        switch (index)
        {
            case 0:
                save0.interactable = false;
                break;
            case 1:
                save1.interactable = false;
                break;
            case 2:
                save2.interactable = false;
                break;
        }

        newGame.interactable = true;

    }

    public void OnClickNewGame()
    {
        if (!sgm.IsSaveSlotEmpty(selectedIndex))
        {
            overWrite.SetActive(true);
            newGame.interactable = false;
            save0.gameObject.SetActive(false);
            save1.gameObject.SetActive(false);
            save2.gameObject.SetActive(false);
            newGame.gameObject.SetActive(false);
        }
        else
        {
            NewGame();
        }
    }

    public void CloseOverwrite()
    {
        overWrite.SetActive(false);
        save0.gameObject.SetActive(true);
        save1.gameObject.SetActive(true);
        save2.gameObject.SetActive(true);
        newGame.gameObject.SetActive(true);
        newGame.interactable = true;
    }

    public void NewGame()
    {
        sgm.NewGame(this.selectedIndex);
        newSceneEvent.Raise();
    }
}
