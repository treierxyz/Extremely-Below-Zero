using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject audioSourceObject;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuButtons;
    public GameObject settings;
    public GameObject mainCharacter;
    private SlowTime slowTime;
    private AudioSource audioSource;
    private float previousTime;
    private float previousMusic;
    private float fixedDeltaTime;
    private bool settingsOpen = false;
    // Update is called once per frame
    void Awake()
    {
        slowTime = mainCharacter.GetComponent<SlowTime>();
        audioSource = audioSourceObject.GetComponent<AudioSource>();
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        if (settingsOpen)
        {
            pauseMenuButtons.SetActive(true);
            settings.SetActive(false);
        }
        pauseMenuUI.SetActive(false);
        if(slowTime.isSlowTime)
        {
            Time.timeScale = previousTime;
            gameIsPaused = false;
            audioSource.pitch = previousMusic;
        }
        else
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            audioSource.pitch = 1f;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        previousTime = Time.timeScale;
        Time.timeScale = 0f;
        gameIsPaused = true;
        previousMusic = audioSource.pitch;
        audioSource.pitch = 0.0f;
    }

    public void LoadMenu()
    {
        pauseMenuButtons.SetActive(false);
        settings.SetActive(true);
        settingsOpen = true;

    }
    public void ExitMenu()
    {
        pauseMenuButtons.SetActive(true);
        settings.SetActive(false);
        settingsOpen = false;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        audioSource.pitch = 1f;
        pauseMenuUI.SetActive(false);
        slowTime.isSlowTime = false;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
