using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private Slider bgSlider;
    [SerializeField]
    private Slider fxSlider;

    public void HandleAudio()
    {
        if (PlayerPrefs.HasKey("bgVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("fxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetFXVolume();
        }
    }

    public void SetFXVolume()
    {
        float volume = fxSlider.value;
        mixer.SetFloat("fxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("fxVolume", volume);
    }

    private void LoadVolume()
    {
        bgSlider.value = PlayerPrefs.GetFloat("bgVolume");
        fxSlider.value = PlayerPrefs.GetFloat("fxVolume");
    }

    public void SetMusicVolume()
    {
        float volume = bgSlider.value;
        mixer.SetFloat("bgVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("bgVolume",volume);
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }
}
