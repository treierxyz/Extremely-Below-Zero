using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoDisplay;
    private Weapon WeaponClip;
    void Awake()
    {
        WeaponClip = GameObject.FindObjectOfType<Weapon>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ammoDisplay.text = (WeaponClip.clipSize).ToString() + "/" + (WeaponClip.clipSizeReal).ToString();
    }
}
