using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // player can only jump!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            /* rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); */
            isGrounded = false;
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = Vector2.up * jumpForce;
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
        /* MovePlayer(); */

    }

    // allows the player to move in all directions
    void MovePlayer()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }

        rb.velocity = moveDirection.normalized * moveSpeed;
    }

    // check if the player collides with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
