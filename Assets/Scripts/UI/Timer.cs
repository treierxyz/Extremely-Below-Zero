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
    public float t;
    public float tOld;
    public string timeInHRF;
    void Start()
    {
        startTime = Time.fixedUnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            t = Time.fixedUnscaledTime - startTime + tOld;
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
        startTime = Time.fixedUnscaledTime;
    }
}
