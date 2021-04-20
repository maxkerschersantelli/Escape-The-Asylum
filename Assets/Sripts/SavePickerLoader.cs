using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePickerLoader : MonoBehaviour
{
    [SerializeField] private SaveGameManagerSO sgm;
    [SerializeField] private Text saveName;
    [SerializeField] private Text saveTime;
    [SerializeField] private int save;
    [SerializeField] private Button button;

    [SerializeField] private bool newSave;

    // Start is called before the first frame update
    void Start()
    {
        saveName.text = "Save: " + this.save.ToString();
        SaveFile currentSave;
        if(this.save == 0)
        {
            currentSave = sgm.GetSave0();
        }
        else if(this.save == 1)
        {
            currentSave = sgm.GetSave1();
        }
        else
        {
            currentSave = sgm.GetSave2();
        }

        if (currentSave.IsBeaten())
        {
            saveName.text = "Save: " + "Finished";
            if (!newSave)
            {
                button.interactable = false;
            }
        }

        if (!newSave && currentSave.IsSaveBlank())
        {
            saveTime.text = "EMPTY";
            button.interactable = false;
        }
        else
        {
            saveTime.text = currentSave.GetTime();
        }
        
    }
}
