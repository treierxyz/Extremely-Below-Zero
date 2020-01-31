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
    public bool doOnce = false;
    public float t;
    public float tOld;
    public string timeInHRF;
    //private float timeC;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.unscaledTime;
        //this.timeC = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (doOnce)
        {
            startTime = Time.fixedUnscaledTime;
        }
        if (canCount)
        {
            t = Time.fixedUnscaledTime - startTime + tOld;
            string minutes = ((int) Mathf.Floor(t) / 60).ToString("00");
            string seconds = (Mathf.Floor(t) % 60).ToString("00");
            timeInHRF = minutes + ":" + seconds;
            timerText.text = timeInHRF;
            doOnce = false;
        }
        else
        {
            tOld = t;
            startTime = Time.fixedUnscaledTime;
            doOnce = true;
        }
    }
}
