using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject audio;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject mainCharacter;
    private SlowTime slowTime;
    private AudioSource audioSource;
    private float previousTime;
    private float previousMusic;
    // Update is called once per frame
    void Awake()
    {
        slowTime = mainCharacter.GetComponent<SlowTime>();
        audioSource = audio.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if(slowTime.isSlowTime)
        {
            Time.timeScale = previousTime;
            GameIsPaused = false;
            audioSource.pitch = previousMusic;
        }
        else
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            audioSource.pitch = 1f;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        previousTime = Time.timeScale;
        Time.timeScale = 0f;
        GameIsPaused = true;
        previousMusic = audioSource.pitch;
        audioSource.pitch = 0.0f;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
    }
    public void QuitToMenu()
    {
        Debug.Log("Quitting");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
