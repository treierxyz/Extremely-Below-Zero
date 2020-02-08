using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    public float timeLeft = 3.0f;
    public TextMeshProUGUI startText; // used for showing countdown from 3, 2, 1 
    public GameObject text;
    public GameObject gsiText;
    public GameObject character;
    public GameObject UI;
    public PauseMenu pauseMenu;
    private SlowTime slowTime;
    private PlayerManager playerManager;
    private Rotator rotator;
    private Weapon weapon;
    private Timer timerScript;
    public bool canCount = true;
    private bool doOnce = false;
    private bool doOnce2 = false;

    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManager = character.GetComponent<PlayerManager>();
        weapon = character.GetComponentInChildren<Weapon>();
        timerScript = UI.GetComponent<Timer>();
    }
    void Update()
    {    
        if (timeLeft >= 0.0f && !pauseMenu.gameIsPausedPublic)
        {
            canCount = true;
        }
        if (timeLeft >= 0.0f && canCount)
        {
            if (!pauseMenu.gameIsPausedPublic)
            {
                timeLeft -= Time.deltaTime;
            }
            startText.text = Mathf.Floor(timeLeft+1).ToString("F0");
        }
        else if (timeLeft <= 0.0f && !doOnce)
        {
            startText.text = "GO!";
            canCount = false;
            doOnce = true;
            gsiText.SetActive(false);
            slowTime.enabled = true;
            playerManager.canMove = true;
            weapon.canShoot = true;
            timerScript.canCount = true;
        }
        if (timeLeft <= 0.0f && !PauseMenu.gameIsPaused)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= -3.0f && !doOnce2)
        {
            doOnce2 = true;
            text.SetActive(false);
        }
    }
}