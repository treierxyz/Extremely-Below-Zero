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
    public GameObject character;
    private SlowTime slowTime;
    private PlayerManger playerManger;
    private Rotator rotator;
    private Weapon weapon;
    public GameObject timer;
    private Timer timerScript;
    private bool canCount = true;
    private bool doOnce = false;

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
        if (timeLeft >= 0.0f && canCount)
        {
            timeLeft -= Time.unscaledDeltaTime;
            startText.text = (timeLeft).ToString("F1");
            
        }
        else if (timeLeft <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                timeLeft = 0.0f;
                text.SetActive(false);
                slowTime.enabled = true;
                playerManger.enabled = true;
                rotator.enabled = true;
                weapon.enabled = true;
                timerScript.canCount = true;
            }
    }
}