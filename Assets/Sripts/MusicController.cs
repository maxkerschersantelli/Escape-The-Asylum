using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private DefaultSettingsSO defautSettings;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<AudioSource>() == null) { gameObject.AddComponent<AudioSource>(); }
        audioSource = GetComponent<AudioSource>();
        SetSettings();
    }

    public void SetSettings()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", defautSettings.musicVolume) / 10;
    }
}
