using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    public float jumpHeight;
    private bool isGrounded;
    public Transform groundTest;
    public float checkRadius;
    public LayerMask ground;
    private Animator animator;
    public float healthStart;
    public float health;
    public bool dead;
    public AudioSource audioSource;
    public AudioSource audioSourceDeath;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = healthStart;
    }

    void FixedUpdate()
    {
        if (health <= 0) 
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            dead = true;
            DeathMusic();
        }
        // Normal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        float moveBy = moveInput * speed;
        if (!dead)
        {
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
        //Animations speed
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        
        // Jumping
        isGrounded = Physics2D.OverlapCircle(groundTest.position, checkRadius, ground);

        //Kill key
        if (Input.GetKeyDown(KeyCode.K))
        {
            health = 0;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetKeyDown(KeyCode.W) && isGrounded == true || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            if(PauseMenu.gameIsPaused == false)
            {
                rb.AddForce(jumpHeight * transform.up, ForceMode2D.Impulse);
                isGrounded = false;
            }
            
        }
    }
    public void TakeDamage(int damage) 
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
    void DeathMusic()
    {
        audioSource.Stop();
        audioSourceDeath.Play();
    }
}
