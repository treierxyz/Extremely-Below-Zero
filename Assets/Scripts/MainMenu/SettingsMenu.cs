using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject musicSlider;
    public GameObject musicFill;
    public GameObject soundSlider;
    public GameObject soundFill;
    public TMP_Dropdown resolutionDropdown;
    private Slider musSlider;
    private Slider sfxSlider;
    private float musicVolume = 0.0f;
    private float soundVolume = 0.0f;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    void Awake()
    {
        musSlider = musicSlider.GetComponent<Slider>();
        sfxSlider = soundSlider.GetComponent<Slider>();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        musicVolume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfxVolume", volume);
        soundVolume = volume;
    }
    public void MuteMusic(bool muted)
    {
        if (muted)
        {
            musSlider.interactable = false;
            musicFill.SetActive(false);
            audioMixer.SetFloat("musicVolume", -80.0f);
        }
        else
        {
            musSlider.interactable = true;
            musicFill.SetActive(true);
            audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20);
        }
    }
    public void MuteSFX(bool muted)
    {
        if (muted)
        {
            sfxSlider.interactable = false;
            soundFill.SetActive(false);
            audioMixer.SetFloat("sfxVolume", -80.0f);
        }
        else
        {
            sfxSlider.interactable = true;
            soundFill.SetActive(true);
            audioMixer.SetFloat("sfxVolume", Mathf.Log10(soundVolume) * 20);
        }
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
