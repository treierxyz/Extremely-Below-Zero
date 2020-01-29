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
        if (canCount)
        {
            t = Mathf.Floor(Time.unscaledTime - startTime);

            string minutes = ((int) t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            startTime = Time.unscaledTime;
        }
    }
}
