using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string masterVolumeKey = "MasterVolume";
    private const string musicVolumeKey = "MusicVolume";
    private const string sfxVolumeKey = "SFXVolume";

    private void Start()
    {
        LoadVolumeSettings();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(masterVolumeKey, volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(musicVolumeKey, volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(sfxVolumeKey, volume);
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey(masterVolumeKey))
        {
            float masterVolume = PlayerPrefs.GetFloat(masterVolumeKey);
            masterSlider.value = masterVolume;
            mixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        }

        if (PlayerPrefs.HasKey(musicVolumeKey))
        {
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
            musicSlider.value = musicVolume;
            mixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        }

        if (PlayerPrefs.HasKey(sfxVolumeKey))
        {
            float sfxVolume = PlayerPrefs.GetFloat(sfxVolumeKey);
            sfxSlider.value = sfxVolume;
            mixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        }
    }
}
