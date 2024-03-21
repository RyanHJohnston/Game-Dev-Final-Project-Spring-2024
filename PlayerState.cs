using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // player properties
    [SerializeField] int health = 100;
    [SerializeField] int damage = 25;

    // player physics
    private Rigidbody2D rb;
    private BoxCollider2D box;

    // player state
    [SerializeField] bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /* box = GetComponent<BoxCollider2D>(); */
    }

    void Update()
    {

    }


    public void TakeDamage(int damageAmount)
    {
        Debug.Log(gameObject.name + " current health: " + health);
        health -= damageAmount;
        if (health <= 0)
        {
            Debug.Log(gameObject.name + " now has been destroyed.");
            Destroy(gameObject);
        } 
        else
        {
            Debug.Log(gameObject.name + " now has " + health + "  health.");
        }
    }

    // when collides with object, take away player health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damage);
        }
    }


}
