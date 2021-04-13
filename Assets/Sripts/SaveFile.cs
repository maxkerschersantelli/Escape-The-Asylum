using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class SaveFile
{
    private string fileName;

    public SaveFile(string name)
    {
        this.fileName = name;
        QuickSaveWriter.Create(fileName)
                       .Write("Name", "Empty")
                       .Commit();
    }

    public void SaveString(string inputName, string input)
    {
        QuickSaveWriter.Create(fileName)
                       .Write(inputName, input)
                       .Commit();
    }

    public void GetString(string inputName, string input)
    {
        QuickSaveReader.Create(fileName)
                       .Read<string>(inputName);
    }

    public void SaveObject(string inputName, object myObject)
    {
        QuickSaveWriter.Create(fileName)
                      .Write(inputName, JsonUtility.ToJson(myObject))
                      .Commit();
    }

    public object GetObject(string inputName)
    {
        return JsonUtility.FromJson<object>(
            QuickSaveReader.Create(fileName)
                       .Read<string>(inputName));
    }

    public string GetName()
    {
        return QuickSaveReader.Create(this.fileName)
                       .Read<string>("Name");
    }

    public void SetName(string name)
    {
        QuickSaveWriter.Create(fileName)
                       .Write("Name", name)
                       .Commit();
    }
}
