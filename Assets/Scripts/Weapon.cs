using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    //public GameObject shotEffect;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void FixedUpdate()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else {
            timeBtwShots -= Time.fixedDeltaTime;
        }

       
    }
}
