using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float moveSpeed = 5f; // Adjusted to a reasonable speed without Time.deltaTime in calculation
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float extraJumpForce = 8f;
    [SerializeField] float maxJumpTime = 0.5f;
    [SerializeField] bool isJumping = false;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier= 2f;
    [SerializeField] float gravityScale = 2f;
    [SerializeField] bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }
        
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
                
        // uncomment to enable double jump, comment out InfiniteJump()
        /* DoubleJump(); */

        // uncomment to enable infinite jumps, comment out DoubleJump()
        InfiniteJump();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (rb.velocity.y < 0)
        {
            // apply higher gravity when falling to make the jump feel more snappy
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // apply higher gravity on jump up phase when the jump button is released
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // uncomment to allow player to move in all directions to test collisions
        // MovePlayer();

    }

    // allows the player to move in all directions
    void MovePlayer()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x += 1;
        }

        rb.velocity = moveDirection.normalized * moveSpeed;
    }
    
    // allows player to double jump
    void DoubleJump()
    {
        // add double jump!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                // regular jump
                rb.velocity = Vector2.up * jumpForce;
                isGrounded = false;
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.velocity = Vector2.up * jumpForce;
                canDoubleJump = false;
            }
        }

    }

    // allows player to have infinite amount of jumps
    void InfiniteJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = maxJumpTime;
            isJumping = true;
        }


        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity += Vector2.up * extraJumpForce * Time.deltaTime;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    // check if the player collides with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }
    
}
