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
    // Jumping
    public float jumpHeight;
    private bool isGrounded;
    public Transform groundTest;
    public float checkRadius;
    public LayerMask ground;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Normal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        // Flips players sprite
        if(moveInput > 0)
        {
            sr.flipX = false;
        } 
        else if(moveInput < 0)
        {
            sr.flipX = true;
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
}
