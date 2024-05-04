using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) && !(gameObject.tag == "StonePillarBottom") && !(gameObject.tag == "StonePillartop"))
        {
            Debug.Log("Destroying " + gameObject.name);
            Destroy(gameObject);            
        }
    }
}
