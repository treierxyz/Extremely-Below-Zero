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
    private SlowTime slowTime;
    private PlayerManger playerManger;
    private Rotator rotator;
    private Weapon weapon;
    public GameObject timer;
    private Timer timerScript;
    public bool canCount = true;
    private bool doOnce = false;
    private bool doOnce2 = false;

    void Start()
    {
        slowTime = character.GetComponent<SlowTime>();
        playerManger = character.GetComponent<PlayerManger>();
        rotator = character.GetComponentInChildren<Rotator>();
        weapon = character.GetComponentInChildren<Weapon>();
        timerScript = timer.GetComponent<Timer>();
    }
    void Update()
    {
        timeLeft -= Time.unscaledDeltaTime;
        if (timeLeft >= 0.0f && canCount)
        {
            startText.text = Mathf.Floor(timeLeft+1).ToString("F0");
            
        }
        else if (timeLeft <= 0.0f && !doOnce)
        {
            startText.text = "GO!";
            canCount = false;
            doOnce = true;
            gsiText.SetActive(false);
            slowTime.enabled = true;
            playerManger.enabled = true;
            weapon.enabled = true;
            timerScript.canCount = true;
        }
        if (timeLeft <= -3.0f && !doOnce2)
        {
            doOnce2 = true;
            text.SetActive(false);
        }
    }
}