using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompleteTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Timer timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        timerText.text = "TIME       " + timer.timeInHRF;
    }
}
