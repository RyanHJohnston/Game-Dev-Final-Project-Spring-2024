using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;

    void Awake()
    {
        movementSpeed = Random.Range(5f, 10f);
    }

    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime; 
    }

}