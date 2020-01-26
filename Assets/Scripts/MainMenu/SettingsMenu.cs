using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject musicSlider;
    public GameObject musicFill;
    public GameObject soundSlider;
    public GameObject soundFill;
    private Slider musSlider;
    private Slider sfxSlider;
    public float musicVolume = 0.0f;
    public float soundVolume = 0.0f;
    // Start is called before the first frame update
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
            audioMixer.SetFloat("musicVolume", musicVolume);
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
            audioMixer.SetFloat("sfxVolume", soundVolume);
        }
    }

}
