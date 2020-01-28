using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
	//TODO Add arm flip, remove turn on key press, use mouse to turn around
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    // For flipping the sprite
    private SpriteRenderer sr;
    private SpriteRenderer sr2;
    // Jumping
    public float jumpHeight;
    private bool isGrounded;
    public Transform groundTest;
    public float checkRadius;
    public LayerMask ground;
    public GameObject arm;
    private Animator animator;

    public float health;

    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr2 = arm.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
            sr.flipX = false;
            sr2.flipX = false;
        } 
        else if(difference.x < 0)
        {
            sr.flipX = true;
            sr2.flipX = true;
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
