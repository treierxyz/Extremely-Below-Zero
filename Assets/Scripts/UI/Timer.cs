using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

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
    NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

    void Start()
    {
        startTime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount && !pauseMenu.gameIsPausedPublic)
        {
            t = (Time.unscaledTime - startTime + tOld) * 1000;
            string minutes = ((int) Mathf.Floor(t/60000)).ToString("00");
            string seconds = ((int) Mathf.Floor(t/1000 % 60)).ToString("00", nfi);
            string millis = ((int) Mathf.Floor(t % 1000)).ToString("000", nfi);
            timeInHRF = "<mspace=0.6em>" + minutes + "</mspace>" + ":" + "<mspace=0.6em>" + seconds + "</mspace>" + "." + "<mspace=0.6em>" + millis + "</mspace>";
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
