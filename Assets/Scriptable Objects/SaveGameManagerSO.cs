using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveGameManager", menuName = "ScriptableObjects/SaveGameManager")]
public class SaveGameManagerSO : ScriptableObject
{
    private SaveFile save0;
    private SaveFile save1;
    private SaveFile save2;

    private SaveFile currentLoad;

    // Start is called before the first frame update
    void OnEnable()
    {
        save0 = new SaveFile("save0");
        save1 = new SaveFile("save1");
        save2 = new SaveFile("save2");
    }

    public void LoadGame(int index)
    {
        switch (index)
        {
            case 0:
                this.currentLoad = save0;
                break;
            case 1:
                this.currentLoad = save1;
                break;
            case 2:
                this.currentLoad = save2;
                break;
        }
    }

    public SaveFile GetCurrentFile()
    {
        if (this.currentLoad == null)
        {
            return save0;
        }
        return this.currentLoad;
    }

    public bool CurrentSaveIsNull()
    {
        return (this.currentLoad == null);
    }

    public SaveFile GetSave0()
    {
        return this.save0;
    }

    public SaveFile GetSave1()
    {
        return this.save1;
    }

    public SaveFile GetSave2()
    {
        return this.save2;
    }
}
