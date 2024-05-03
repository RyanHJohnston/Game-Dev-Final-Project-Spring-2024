using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;

    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime; 
    }
}
