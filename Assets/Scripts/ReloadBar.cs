using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    public GameObject reloadingBar;
    public GameObject arm;
    private Weapon reloadingStat;
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
        reloadingStat = arm.GetComponent<Weapon>();
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadingStat.isReloading == true)
        {
            //reloadingBar.SetActive(true);
            CurrentValue = 1-(reloadingStat.reloadTimeHidden/reloadingStat.reloadTime);
        } 
        else
        {
            //reloadingBar.SetActive(false);
            CurrentValue = reloadingStat.clipSizeReal/reloadingStat.clipSize;
        }
    }
}
