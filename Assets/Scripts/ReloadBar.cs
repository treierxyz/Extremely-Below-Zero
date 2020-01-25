using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;

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
        CurrentValue += 0.0043f;
    }
}
