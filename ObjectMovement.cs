using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    void Awake()
    {
        movementSpeed = 5f;
        if (gameObject.tag == "Bat" || gameObject.tag == "RobotEnemy")
        {
            movementSpeed += 5f;
        }
    }

    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime; 
    }



}
