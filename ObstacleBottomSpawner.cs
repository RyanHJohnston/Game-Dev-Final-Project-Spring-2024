using System.Collections;
using UnityEngine;

public class ObstacleBottomSpawner : MonoBehaviour
{
    public GameObject obstacleBottomObject; // The prefab to spawn
    public float spawnInterval = 2f; // Time between each spawn
    public Transform objectLocation;
    public float defaultX = 0.2331112f;
    public float defaultY = 0.2543209f;
    private float spawnX = 11.41f;
    private float spawnY = -3.893f;
    public Rigidbody2D rb;
    
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
        Instantiate(obstacleBottomObject, spawnLocation, Quaternion.identity);
    }

    /* public void Spawn() */
    /* { */
    /*     float scaleMultiplier = Random.Range(1.0f, 2.0f); */
    /*     transform.localScale = new Vector3(defaultX * scaleMultiplier, defaultY * scaleMultiplier, 1); */
    /* } */

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(obstacleBottomObject);
        }
    }
}
