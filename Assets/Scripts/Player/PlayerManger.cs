using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    public float speed;
    public float speedslow;
    public float movespeed;
    private float moveInput;
    private Rigidbody2D rb;
    // Jumping
    public float jumpHeight;
    private bool isGrounded;
    public Transform groundTest;
    public float checkRadius;
    public LayerMask ground;
    private Animator animator;
    public float healthStart;
    public float health;

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
            Destroy(gameObject);
        }
        // Normal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //Animations speed
        if (rb.velocity.x < 0)
        {
            animator.SetFloat("speed", -rb.velocity.x);
        }
        else if (rb.velocity.x > 0)
        {
            animator.SetFloat("speed", rb.velocity.x);
        }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Flips players sprite
        if(difference.x > 0)
        {
            Vector3 charScale = new Vector3(5,transform.localScale.y,transform.localScale.z);
            transform.localScale = charScale;
            
        } 
        else if(difference.x < 0)
        {
            Vector3 charScale = new Vector3(-5,transform.localScale.y,transform.localScale.z);
            transform.localScale = charScale;
        }
        // Jumping
        isGrounded = Physics2D.OverlapCircle(groundTest.position, checkRadius, ground);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetKeyDown(KeyCode.W) && isGrounded == true || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            if(PauseMenu.GameIsPaused == false)
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
}
