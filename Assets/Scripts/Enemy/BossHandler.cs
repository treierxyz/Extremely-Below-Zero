using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    public int health;
    public float timeBtwHits;
    private float alsotimeBtwHits;
    private bool Hit;
    private void Update()
    {
        if (health <= 0) 
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (alsotimeBtwHits <= 0)
        {
            Hit = true;
        }
        else
        {
            Hit = false;
            alsotimeBtwHits -= Time.fixedDeltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && Hit == true)
        {
            col.gameObject.GetComponent<PlayerManger>().TakeDamage(1);
            alsotimeBtwHits = timeBtwHits;
        }
    }
    
    public void TakeDamage(int damage) 
    {
        
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}