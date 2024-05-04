using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinInitial : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Gold Coin Init collided with Player/Enemy: Destroyed");
        }
    }
}
