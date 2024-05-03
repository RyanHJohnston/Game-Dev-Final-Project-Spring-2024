using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldCoinSpawner : MonoBehaviour
{
    public GameObject goldCoinObject;
    public float spawnInterval = 2f;
    public Rigidbody2D rb;
    public float xAxisSpawn = 11.30f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 2.0f, 150f);
    }
    
    public void Spawn()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(xAxisSpawn, xAxisSpawn + 10), Random.Range(3f, -3f), 0);
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
