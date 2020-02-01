using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    public int health;
    public float timeBtwHits;
    private float alsotimeBtwHits;
    private bool Hit;
    
    private void FixedUpdate()
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


    // Combat


    private float attackChoice;
    private bool attackDone;
    private float timeBtwAttacks = 2f;
    private float alsoTimeBtwAttacks;
    public GameObject bossDefault;
    private Rigidbody2D rb;

    private void Start()
    {
        alsoTimeBtwAttacks = timeBtwAttacks;
        attackDone = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(attackDone == true)
        {
            if (alsoTimeBtwAttacks <= 0)
            {
                attackChoice = Random.Range(1, 4);
                if(attackChoice == 1.0)
                {
                    Attack1();
                }
                if(attackChoice == 2.0)
                {
                    Attack2();
                } 
                if(attackChoice == 3.0)
                {
                    Attack3();
                } 
            }
            else
            {
                alsoTimeBtwAttacks -= Time.fixedDeltaTime;
            }
        }
    }
    private void Attack1()
    {
        attackDone = false;
        
        if(gameObject.transform.position == bossDefault.gameObject.transform.position)
        {
            attackDone = true;
            Debug.Log("1");
            alsoTimeBtwAttacks = timeBtwAttacks;
        }
    }
    private void Attack2()
    {
        attackDone = false;
        if(gameObject.transform.position == bossDefault.gameObject.transform.position)
        {
            attackDone = true;
            Debug.Log("2");
            alsoTimeBtwAttacks = timeBtwAttacks;
        }
    }
    private void Attack3()
    {
        attackDone = false;
        if(gameObject.transform.position == bossDefault.gameObject.transform.position)
        {
            attackDone = true;
            Debug.Log("3");
            alsoTimeBtwAttacks = timeBtwAttacks;
        }
    }







}   