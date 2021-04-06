using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSettings", order = 1)]
public class DefaultSettingsSO : ScriptableObject
{
    public float musicVolume;
    public float soundEffectVolume;

    public float movementSpeed;
    public float lookSensitivity;

    public int leftStickMode;
    public int leftStickAction;
    public float leftStickDeadZone;

    public int rightStickMode;
    public int rightStickAction;
    public float rightStickDeadZone;

    public int invert;

}
