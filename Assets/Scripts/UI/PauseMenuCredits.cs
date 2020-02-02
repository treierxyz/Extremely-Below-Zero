using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCredits : MonoBehaviour
{
    public GameObject audioSourceObject;
    public static bool gameIsPaused = false;
    public bool gameIsPausedPublic = false;
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
    //public GameObject overlay;
    // Update is called once per frame
    void Awake()
    {
        slowTime = mainCharacter.GetComponent<SlowTime>();
        audioSource = audioSourceObject.GetComponent<AudioSource>();
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
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
            settingsOpen = false;
        }
        else
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            gameIsPausedPublic = false;
            audioSource.pitch = 1f;
            pauseMenuUI.SetActive(false);
            //overlay.SetActive(true);
        }
        
    }

    void Pause()
    {
        gameIsPaused = true;
        gameIsPausedPublic = true;
        //overlay.SetActive(false);
        pauseMenuUI.SetActive(true);
        previousTime = Time.timeScale;
        Time.timeScale = 0f;
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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        audioSource.pitch = 1f;
        pauseMenuUI.SetActive(false);
        slowTime.isSlowTime = false;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);
    }
}
