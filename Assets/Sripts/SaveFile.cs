using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;
using System;

public class SaveFile
{
    private string fileName;
    private FileSaveData file;
    private PlayerSaveData player;

    public SaveFile(string name)
    {
        this.fileName = name;

        try
        {
            QuickSaveReader.Create(fileName)
                       .Read<string>("File", (r) => { this.file = JsonUtility.FromJson<FileSaveData>(r); });
            QuickSaveReader.Create(fileName)
                       .Read<string>("Player", (r) => { this.player = JsonUtility.FromJson<PlayerSaveData>(r); });
        }
        catch (Exception e)
        {
            Debug.Log("no save file found");
            ResetFile();
        }
        Debug.Log("Save Found");
    }

    public void LoadFromFile()
    {
        QuickSaveReader.Create(fileName)
                       .Read<string>("File", (r) => { this.file = JsonUtility.FromJson<FileSaveData>(r); });

        QuickSaveReader.Create(fileName)
                       .Read<string>("Player", (r) => { this.player = JsonUtility.FromJson<PlayerSaveData>(r); });
    }

    public void ResetFile()
    {
        this.file = new FileSaveData();
        this.file.time = 0;
        this.file.finished = false;
        SaveFileSaveData(this.file);

        this.player = new PlayerSaveData();
        this.player.x = 0;
        this.player.y = 1.3f;
        this.player.z = 0;

        this.player.xLook = 0;
        this.player.yLook = 0;
        this.player.zLook = 0;
        SavePlayerSaveData(this.player);
    }

    public void SaveString(string inputName, string input)
    {
        QuickSaveWriter.Create(fileName)
                       .Write(inputName, input)
                       .Commit();
    }

    public void GetString(string inputName)
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

    public void SaveFileSaveData(FileSaveData fileData)
    {
        this.file = fileData;
        QuickSaveWriter.Create(fileName)
                      .Write("File", JsonUtility.ToJson(fileData))
                      .Commit();
    }
    
    public FileSaveData GetFileSaveData()
    {
        return this.file;
    }

    public void SavePlayerSaveData(PlayerSaveData playerData)
    {
        this.player = playerData;
        QuickSaveWriter.Create(fileName)
                      .Write("Player", JsonUtility.ToJson(playerData))
                      .Commit();
    }

    public PlayerSaveData GetPlayerSaveData()
    {
        return this.player;
    }

    public void SaveGame()
    {
        Debug.Log("save game");
        this.file.time += Time.timeSinceLevelLoad;
        this.SaveFileSaveData(this.file);
        this.SavePlayerSaveData(this.player);

    }

    public string GetTime()
    {
        float time = this.file.time;
        int seconds = (int)(time % 60); // return the remainder of the seconds divide by 60 as an int
        time /= 60; // divide current time y 60 to get minutes
        int minutes = (int)(time % 60); //return the remainder of the minutes divide by 60 as an int
        time /= 60; // divide by 60 to get hours
        int hours = (int)(time % 24); // return the remainder of the hours divided by 60 as an int
        return string.Format("{0}:{1}:{2}", hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"));
    }

    public bool IsSaveBlank()
    {
        if(this.file.time == 0)
        {
            return true;
        }
        return false;
    }

    public bool IsBeaten()
    {
        return this.file.finished;
    }
}

public struct FileSaveData
{
    public float time;
    public bool finished;
}

public struct PlayerSaveData
{
    public float x;
    public float y;
    public float z;

    public float xLook;
    public float yLook;
    public float zLook;
}
