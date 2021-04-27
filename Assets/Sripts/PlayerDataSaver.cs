using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSaver : MonoBehaviour
{
    [SerializeField] private SaveGameManagerSO sgm;
    [SerializeField] private GameObject playerCamera;

    public void OnEnable()
    {
        PlayerSaveData player = sgm.GetCurrentFile().GetPlayerSaveData();
        gameObject.transform.position = new Vector3(player.x, player.y, player.z);

        Debug.Log(player.xLook);
        Debug.Log(player.yLook);
        gameObject.transform.localRotation = Quaternion.Euler(0, player.yLook, 0);

        playerCamera.transform.rotation = Quaternion.Euler(player.xLook, 0, 0);
    }

    public void SavePlayerData()
    {
        PlayerSaveData player = new PlayerSaveData();
        player.x = gameObject.transform.position.x;
        player.y = gameObject.transform.position.y;
        player.z = gameObject.transform.position.z;


        player.xLook = playerCamera.transform.localRotation.eulerAngles.x;
        player.yLook = gameObject.transform.localRotation.eulerAngles.y;
        player.zLook = 0;
        sgm.GetCurrentFile().SavePlayerSaveData(player);
    }

    void OnApplicationQuit()
    {
        this.SavePlayerData();


        FileSaveData file = sgm.GetCurrentFile().GetFileSaveData();
        file.time += Time.timeSinceLevelLoad;
        sgm.GetCurrentFile().SaveFileSaveData(file);
        sgm.SaveCurrentGame();
        Debug.Log("OnApplicationQuit");
    }
}
