using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject player;
    public CanSeeScript cansee;
    private float posDif;
    private Rigidbody2D rb;
    public float enemySpeed;
    public bool inVision;
    //public GameObject deathEffect;
    //public GameObject explosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (health <= 0) 
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (cansee.inVision)
            {
            posDif = player.transform.position.x - transform.position.x;
            if(posDif >= 5 || posDif < 0 && posDif > -2.5)
            {
                rb.velocity = new Vector2(1 * enemySpeed, rb.velocity.y);
            }
            if(posDif <= -5 || posDif > 0 && posDif < 2.5)
            {
                rb.velocity = new Vector2(-1 * enemySpeed, rb.velocity.y);
            }
        }

    }

    public void TakeDamage(int damage) 
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
