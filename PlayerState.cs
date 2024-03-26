using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // player properties
    [SerializeField] int health = 100;
    [SerializeField] int damage = 25;
    [SerializeField] int totalCoinValue;
    [SerializeField] int coinValue = 25;

    // player physics
    private Rigidbody2D rb;
    private BoxCollider2D box;

    public TextMesh coinText;

    // player state
    [SerializeField] bool isDead;

    void Awake()
    {
        totalCoinValue = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log(gameObject.name + " current health: " + health);
        health -= damageAmount;
        
        // damage taken from enemies
        if (health <= 0)
        {
            Debug.Log(gameObject.name + " now has been destroyed.");
            Destroy(gameObject);
        } 
        else
        {
            Debug.Log(gameObject.name + " now has " + health + "  health.");
        }

        // damage taken from obstacles
        // write code here
    }

    /*
     * Add coin method here
     */
    public void AddCoin(int coinValue)
    {
        Debug.Log(gameObject.name + " total coins: " + totalCoinValue);
        totalCoinValue += coinValue;
    }
    

    /// <summary>
    /// If "Event", change player state.
    /// This applies to gold coins, power-ups, enemies, and objects.
    /// <param name="collision">[TODO:description]</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
                collision.gameObject.CompareTag("StonePillarTop") ||
                collision.gameObject.CompareTag("StonePillarBottom"))
        {
            TakeDamage(damage);
            transform.position = new Vector3(-5.511f, -4.106f, 0);

        }

        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            AddCoin(coinValue);
        }
    }




}
