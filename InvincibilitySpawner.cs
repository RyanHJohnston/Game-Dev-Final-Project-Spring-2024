using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilitySpawner : MonoBehaviour
{
    public GameObject invincibilityObject;
    public float spawnInterval = 2f;
    public Rigidbody2D rb;
    public float xAxisSpawn = 11.30f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 10f;
    public int maxActiveObjects = 1; // Maximum number of objects that can be active at once

    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 2.0f, 150f);
        StartCoroutine(SpawnObjectAtRandomIntervals());
    }

    private IEnumerator SpawnObjectAtRandomIntervals()
    {
        while (true)
        {
            while (spawnedObjects.Count >= maxActiveObjects)
            {
                yield return null; // Wait until there's room to spawn a new object
            }

            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            GameObject newObject = Instantiate(invincibilityObject, transform.position, Quaternion.identity);
            spawnedObjects.Add(newObject);
            StartCoroutine(RemoveFromListAfterSeconds(newObject, 10)); // Adjust time as needed
        }
    }

    private IEnumerator RemoveFromListAfterSeconds(GameObject objectToRemove, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        spawnedObjects.Remove(objectToRemove);
        Destroy(objectToRemove);
    }
    
    public void Spawn()
    {
        Vector3 spawnLocation = new Vector3(xAxisSpawn, Random.Range(3f, -3f), 0);
        Instantiate(invincibilityObject, spawnLocation, Quaternion.identity);
    }

    // private IEnumerator SpawnObjectAtRandomIntervals()
    // {
    //     while (true) // Loop indefinitely
    //     {
    //         yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval)); // Wait for a random duration within the specified range
    //         Instantiate(invincibilityObject, transform.position, Quaternion.identity); // Instantiate the object at the spawner's position
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(invincibilityObject);
        }
    }


    // public GameObject InvincibilityObject;
    // public float spawnInterval = 2f;
    // public Rigidbody2D rb;
    // public float xAxisSpawn = 11.30f;
    
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     InvokeRepeating("Spawn", 2.0f, 150f);
    // }
    
    // public void Spawn()
    // {
    //     Vector3 spawnLocation = new Vector3(Random.Range(xAxisSpawn, xAxisSpawn + 50f), Random.Range(3f, -3f), 0);
    //     Instantiate(InvincibilityObject, spawnLocation, Quaternion.identity);
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(InvincibilityObject);
    //     }
    // }
}
