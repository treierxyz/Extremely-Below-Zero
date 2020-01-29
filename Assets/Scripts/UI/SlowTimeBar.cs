using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlowTimeBar : MonoBehaviour
{
    public TextMeshProUGUI slowTimeDisplay;
    public Slider slider;
    public GameObject reloadingBar;
    public SlowTime slowTime;
    private float currentValue = 0f;
    public float CurrentValue {
    get {
        return currentValue;
    }
    set {
        currentValue = value;
        slider.value = currentValue;
    }
}
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue = slowTime.slowDownRemaining/slowTime.slowDownDuration;
        slowTimeDisplay.text = (slowTime.slowDownRemaining).ToString("F1") + "/" + (slowTime.slowDownDuration).ToString();
    }
}
