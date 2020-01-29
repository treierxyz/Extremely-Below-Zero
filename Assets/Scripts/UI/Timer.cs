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
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canCount)
        {
            t = Mathf.Floor(Time.time - startTime);

            string minutes = ((int) t / 60).ToString("00");
            string seconds = "";

            seconds = (t).ToString("00");


            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            startTime = Time.time;
        }
    }
}
