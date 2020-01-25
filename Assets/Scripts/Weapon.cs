﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    //public GameObject shotEffect;
    public Transform shotPoint;
    public float clipSize;
    public float clipSizeReal;
    public float reloadTime;
    public float reloadTimeHidden;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool isReloading;
    private void Start()
    {
        clipSizeReal = clipSize;
        reloadTimeHidden = reloadTime;
    }
    private void FixedUpdate()
    {
        if(clipSizeReal > 0)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                    clipSizeReal -= 1;
                }
            }
            else 
            {
                timeBtwShots -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if(reloadTimeHidden <= 0)
            {
                isReloading = false;
                clipSizeReal = clipSize;
                reloadTimeHidden = reloadTime;
            }
            else
            {
                isReloading = true;
                reloadTimeHidden -= Time.fixedDeltaTime;
            }
            
        }
    }
}
