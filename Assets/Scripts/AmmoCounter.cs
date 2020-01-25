using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoDisplay;
    private float ammoAmount;
    private float clipSize;
    // Start is called before the first frame update
    private void Start()
    {
        clipSize = Weapon.clipSize;
        ammoAmount = Weapon.clipSizeReal;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ammoDisplay.text = (ammoAmount).ToString() + "/" + (clipSize).ToString();
    }
}
