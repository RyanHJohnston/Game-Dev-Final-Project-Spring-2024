using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f; // Adjusted to a reasonable speed without Time.deltaTime in calculation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        
        if(Input.GetKey(KeyCode.DownArrow)) {
            moveDirection.y = -5;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            moveDirection.x = 5;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            moveDirection.y = 5;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveDirection.x = -5;
        }

        rb.velocity = moveDirection.normalized * moveSpeed; // Removed Time.deltaTime from here
    }
}
