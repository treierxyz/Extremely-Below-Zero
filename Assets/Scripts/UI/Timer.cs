using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    public bool canCount = false;
    //public bool tS = true;
    public float t;
    public float tOld;
    public string timeInHRF;
    public PauseMenu pauseMenu;

    void Start()
    {
        startTime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (tS)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }*/
        if (canCount && !pauseMenu.gameIsPausedPublic)
        {
            t = Time.unscaledTime - startTime + tOld;
            string minutes = ((int) Mathf.Floor(t) / 60).ToString("00");
            string seconds = (Mathf.Floor(t) % 60).ToString("00");
            timeInHRF = minutes + ":" + seconds;
            timerText.text = timeInHRF;
        }
        else
        {
            SetOldTime();
        }
    }
    public void SetOldTime()
    {
        tOld = t;
        startTime = Time.unscaledTime;
    }
}
