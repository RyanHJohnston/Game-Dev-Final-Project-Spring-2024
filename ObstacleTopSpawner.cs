using System.Collections;
using UnityEngine;

public class ObstacleTopSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacleTopObject; // The prefab to spawn
    [SerializeField] float spawnInterval = 2f; // Time between each spawn
    [SerializeField] Transform objectLocation;
    [SerializeField] float defaultX = 0.2331112f;
    [SerializeField] float defaultY = 0.2543209f;
    [SerializeField] Rigidbody2D rb;
   
    private float spawnX = 11.41f;
    private float spawnY = 3.87f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 2.0f, 150f);
    }

    public void Spawn()
    {
        Vector3 spawnLocation = new Vector3(spawnX, spawnY, 0);
        float scaleMultiplier = Random.Range(1.0f, 2.0f);
        transform.localScale = new Vector3(defaultX * scaleMultiplier, defaultY * scaleMultiplier, 1);
        Instantiate(obstacleTopObject, spawnLocation, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(obstacleTopObject);
        }
    }
}
