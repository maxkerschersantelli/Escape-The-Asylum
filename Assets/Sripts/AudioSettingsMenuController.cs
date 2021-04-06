using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenuController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectSlider;
    [SerializeField] private DefaultSettingsSO defaultSettings;
    [SerializeField] private GameEvent audioSettingsEvent;

    private void OnEnable()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", defaultSettings.musicVolume);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", defaultSettings.soundEffectVolume);
    }

    public void ApplyOnClick()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectSlider.value);
        audioSettingsEvent.Raise();
    }

    public void RevertOnClick()
    {
        musicSlider.value = defaultSettings.musicVolume;
        soundEffectSlider.value = defaultSettings.soundEffectVolume;
    }
}
