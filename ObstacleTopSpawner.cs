using System.Collections;
using UnityEngine;

public class ObstacleTopSpawner : MonoBehaviour
{
    public GameObject obstacleTopObject; // The prefab to spawn
    public float spawnInterval = 2f; // Time between each spawn
    private Coroutine spawnCoroutine; // Reference to the spawning coroutine
    public Transform objectLocation;
    public float minHeight = 4.0f;
    public float maxHeight = 8.0f;
    public Rigidbody2D object2D;

    void Start()
    {
        object2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 1.5f, 150f);
    }

    public void Spawn()
    {
        Vector3 bottomRight = new Vector3(11.4f, 4.41f, 0); // z is set to 0 for 2D
        float randomHeight = Random.Range(minHeight, maxHeight);

        obstacleTopObject.transform.localScale = new Vector3(
                obstacleTopObject.transform.localScale.x,
                randomHeight,
                obstacleTopObject.transform.localScale.z);

        Instantiate(obstacleTopObject, bottomRight, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(obstacleTopObject);
        }
    }
}


