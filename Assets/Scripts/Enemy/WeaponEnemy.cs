    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public GameObject projectile;
    public Enemy enemy;
    public Transform shotPoint;
    public float clipSize;
    private float clipSizeReal;
    public float reloadTime;
    private float reloadTimeHidden;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private bool isReloading;

    void Start()
    {
        clipSizeReal = clipSize;
        reloadTimeHidden = reloadTime;
        isReloading = false;
    }
    void Update()
    {
        if(clipSizeReal > 0 && isReloading == false)
        {
            if (timeBtwShots <= 0 && enemy.inVision)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                clipSizeReal -= 1;
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
