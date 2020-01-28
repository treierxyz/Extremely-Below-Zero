using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Text ammoDisplay;
    public Slider slider;
    public GameObject reloadingBar;
    public GameObject arm;
    private Weapon weapon;
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
        weapon = arm.GetComponent<Weapon>();
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon.isReloading == true)
        {
            //reloadingBar.SetActive(true);
            CurrentValue = 1-(weapon.reloadTimeHidden/weapon.reloadTime);
        } 
        else
        {
            //reloadingBar.SetActive(false);
            CurrentValue = weapon.clipSizeReal/weapon.clipSize;
        }
        ammoDisplay.text = (weapon.clipSize).ToString() + "/" + (weapon.clipSizeReal).ToString();
    }
}
