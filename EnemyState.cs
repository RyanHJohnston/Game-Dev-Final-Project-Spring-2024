using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();    
    
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | 
            RigidbodyConstraints2D.FreezePositionY |
            RigidbodyConstraints2D.FreezeRotation;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            Debug.Log("Enemy collided with gold coin!");
        }
    }
}
