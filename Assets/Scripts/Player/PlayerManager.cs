using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    public float jumpHeight;
    private bool isGrounded;
    public bool isBlinking;
    public Transform groundTest;
    public float checkRadius;
    public LayerMask ground;
    private Animator animator;
    public float healthStart;
    public float health;
    public bool dead;
    public bool canMove = false;
    private Flipper flipper;
    public AudioSource audioSource;
    public AudioSource audioSourceDeath;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
		flipper = GetComponent<Flipper>();
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
        if (canMove)
        {
            moveInput = Input.GetAxis("Horizontal");
            float moveBy = moveInput * speed;
            if (!dead)
            {
                rb.velocity = new Vector2(moveBy, rb.velocity.y);
            }

            // Jumping
            isGrounded = Physics2D.OverlapCircle(groundTest.position, checkRadius, ground);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if(animator.GetCurrentAnimatorStateInfo(1).IsName("blinkAnim"))
        {
            isBlinking = true;
        }
        else
        {
            isBlinking = false;
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            if(!PauseMenu.gameIsPaused && canMove)
            {
                rb.AddForce(jumpHeight * transform.up, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
        if (isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }
		//Kill key
        if (Input.GetKeyDown(KeyCode.K))
        {
            health = 0;
        }
		//Animations speed
		if (rb.velocity.x > 0 && !flipper.m_FacingRight || rb.velocity.x < 0 && flipper.m_FacingRight )
		{
			animator.SetFloat("speedBack", Mathf.Abs(rb.velocity.x));
			animator.SetFloat("speed", 0);
            animator.SetBool("left", true);
            animator.SetBool("right", false);
		}
        else
		{
			animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
			animator.SetFloat("speedBack", 0);
            animator.SetBool("left", false);
            animator.SetBool("right", true);
		}
        if (flipper.m_FacingRight)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }
        else
        {
            animator.SetBool("left", true);
            animator.SetBool("right", false);
        }
    }
    public void TakeDamage(int damage) 
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
    public void BlinkHurt() 
    {
        if(!isBlinking)
        {
            animator.SetTrigger("blinky");
            health -= 1;
        }
    }
    void DeathMusic()
    {
        audioSource.Stop();
        audioSourceDeath.Play();
    }
}
