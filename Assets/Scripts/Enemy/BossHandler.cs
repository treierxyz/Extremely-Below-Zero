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
            col.gameObject.GetComponent<PlayerManager>().TakeDamage(1);
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
    private bool attackDone = true;
    private float timeBtwAttacks = 2f;
    private float alsoTimeBtwAttacks = 0f;
    public GameObject BossDefault;
    public GameObject AttackPos1;
    public GameObject AttackPos2;
    private Rigidbody2D rb;
    private bool returning = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(returning == true)
        {
            Vector2 a = BossDefault.gameObject.transform.position - gameObject.transform.position;
            gameObject.transform.Translate(a / 100);
        }
        if(gameObject.transform.position == BossDefault.gameObject.transform.position && returning == true)
        {
            returning = false;
            attackDone = true;
            alsoTimeBtwAttacks = timeBtwAttacks;
        }
        if(attackDone == true)
        {
            if (alsoTimeBtwAttacks <= 0)
            {
                attackChoice = Random.Range(1, 4);
                if(attackChoice == 1)
                {
                    Attack1();
                }
                if(attackChoice == 2)
                {
                    Attack1();
                } 
                if(attackChoice == 3)
                {
                    Attack1();
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
        Vector2 b = AttackPos1.gameObject.transform.position - gameObject.transform.position;
        gameObject.transform.Translate(b / 100);
        if(gameObject.transform.position == AttackPos1.gameObject.transform.position)
        {
            Vector2 c = AttackPos2.gameObject.transform.position - gameObject.transform.position;
            gameObject.transform.Translate(c / 100);
        }
        if(gameObject.transform.position == AttackPos2.gameObject.transform.position)
        {
            returning = true;
        }
        
    }
    private void Attack2()
    {
        attackDone = false;
        Vector2 b = AttackPos1.gameObject.transform.position - gameObject.transform.position;
        gameObject.transform.Translate(b / 100);
        if(gameObject.transform.position == AttackPos1.gameObject.transform.position)
        {
            Vector2 c = AttackPos2.gameObject.transform.position - gameObject.transform.position;
            gameObject.transform.Translate(c / 100);
        }
        if(gameObject.transform.position == AttackPos2.gameObject.transform.position)
        {
            returning = true;
        }
    }
    private void Attack3()
    {
        attackDone = false;
        Vector2 b = AttackPos1.gameObject.transform.position - gameObject.transform.position;
        gameObject.transform.Translate(b / 100);
        if(gameObject.transform.position == AttackPos1.gameObject.transform.position)
        {
            Vector2 c = AttackPos2.gameObject.transform.position - gameObject.transform.position;
            gameObject.transform.Translate(c / 100);
        }
        if(gameObject.transform.position == AttackPos2.gameObject.transform.position)
        {
            returning = true;
        }
    }







}   