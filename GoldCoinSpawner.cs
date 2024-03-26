using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinSpawner : MonoBehaviour
{
    public GameObject goldCoinObject;
    public float spawnInterval = 2f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 2.0f, 150f);
    }
    
    public void Spawn()
    {
        Vector3 spawnLocation = new Vector3(11.30f, Random.Range(-4.45f, 4.45f), 0);
        Instantiate(goldCoinObject, spawnLocation, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(goldCoinObject);
        }
    }
}
