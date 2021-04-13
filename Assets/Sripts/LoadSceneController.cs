using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CI.QuickSave;
using System;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] Button save0;
    [SerializeField] Button save1;
    [SerializeField] Button save2;
    [SerializeField] Text save0Text;
    [SerializeField] Text save1Text;
    [SerializeField] Text save2Text;

    [SerializeField] Button load;

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
        load.interactable = false;
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

        load.interactable = true;

    }

    public void OnClickLoad()
    {
        sgm.LoadGame(this.selectedIndex);
        newSceneEvent.Raise();
    }
}
