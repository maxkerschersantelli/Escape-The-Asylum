using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenuController : MonoBehaviour
{
    [SerializeField] private Slider movementSpeedSlider;
    [SerializeField] private Slider lookSensitivitySlider;

    [SerializeField] private Dropdown leftStickMode;
    [SerializeField] private Dropdown leftStickAction;
    [SerializeField] private Slider leftStickDeadZoneSlider;

    [SerializeField] private Dropdown rightStickMode;
    [SerializeField] private Dropdown rightStickAction;
    [SerializeField] private Slider rightStickDeadZoneSlider;

    [SerializeField] private Toggle invert;

    [SerializeField] private DefaultSettingsSO defaultSettings;
    [SerializeField] private GameEvent controlSettingsEvent;

    // Start is called before the first frame update
    void OnEnable()
    {
        movementSpeedSlider.value = PlayerPrefs.GetFloat("MovementSpeed", defaultSettings.movementSpeed);
        lookSensitivitySlider.value = PlayerPrefs.GetFloat("LookSensitivity", defaultSettings.lookSensitivity);

        leftStickMode.value = PlayerPrefs.GetInt("LeftStickMode", defaultSettings.leftStickMode);
        leftStickAction.value = PlayerPrefs.GetInt("LeftStickAction", defaultSettings.leftStickAction);
        leftStickDeadZoneSlider.value = PlayerPrefs.GetFloat("LeftStickDeadZone", defaultSettings.leftStickDeadZone);

        rightStickMode.value = PlayerPrefs.GetInt("RightStickMode", defaultSettings.rightStickMode);
        rightStickAction.value = PlayerPrefs.GetInt("RightStickAction", defaultSettings.rightStickAction);
        rightStickDeadZoneSlider.value = PlayerPrefs.GetFloat("RightStickDeadZone", defaultSettings.rightStickDeadZone);

        if(PlayerPrefs.GetInt("Invert", defaultSettings.invert) == 0)
        {
            invert.isOn = false;
        }
        else
        {
            invert.isOn = true;
        }
    }

    public void ApplyOnClick()
    {
        PlayerPrefs.SetFloat("MovementSpeed", movementSpeedSlider.value);
        PlayerPrefs.SetFloat("LookSensitivity", lookSensitivitySlider.value);

        PlayerPrefs.SetInt("LeftStickMode", leftStickMode.value);
        PlayerPrefs.SetInt("LeftStickAction", leftStickAction.value);
        PlayerPrefs.SetFloat("LeftStickDeadZone", leftStickDeadZoneSlider.value);

        PlayerPrefs.SetInt("RightStickMode", rightStickMode.value);
        PlayerPrefs.SetInt("RightStickAction", rightStickAction.value);
        PlayerPrefs.SetFloat("RightStickDeadZone", rightStickDeadZoneSlider.value);

        if (invert.isOn)
        {
            PlayerPrefs.SetInt("Invert", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Invert", 0);
        }
        controlSettingsEvent.Raise();
    }

    public void RevertOnClick()
    {
        movementSpeedSlider.value = defaultSettings.movementSpeed;
        lookSensitivitySlider.value = defaultSettings.lookSensitivity;

        leftStickMode.value = defaultSettings.leftStickMode;
        leftStickAction.value = defaultSettings.leftStickAction;
        leftStickDeadZoneSlider.value = defaultSettings.leftStickDeadZone;

        rightStickMode.value = defaultSettings.rightStickMode;
        rightStickAction.value = defaultSettings.rightStickAction;
        rightStickDeadZoneSlider.value = defaultSettings.rightStickDeadZone;

        if (defaultSettings.invert == 0)
        {
            invert.isOn = false;
        }
        else
        {
            invert.isOn = true;
        }
    }
}
