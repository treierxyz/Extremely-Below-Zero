using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    public GameObject reloadingBar;
    private Weapon Reloading;
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
    void Awake()
    {
        Reloading = GameObject.FindObjectOfType<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Reloading.isReloading)
        {
            reloadingBar.SetActive(true);
            Debug.Log("Reloading");
            CurrentValue = -(Reloading.reloadTimeHidden / Reloading.reloadTime);
        } 
        else
        {
            reloadingBar.SetActive(false);
            Debug.Log("Not reloading");
            CurrentValue = Reloading.reloadTime;
        }
    }
}
