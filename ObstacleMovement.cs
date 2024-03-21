using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NOTE: Accelerate the obstacle's movement as time passes
 * I don't know how you'll do it but FIGURE IT OUT
 */
public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
