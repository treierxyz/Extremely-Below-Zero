using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoDisplay;
    public GameObject arm;
    private Weapon WeaponClip;
    void Awake()
    {
        WeaponClip = arm.GetComponent<Weapon>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ammoDisplay.text = "Ammo: "+(WeaponClip.clipSize).ToString() + "/" + (WeaponClip.clipSizeReal).ToString();
    }
}
