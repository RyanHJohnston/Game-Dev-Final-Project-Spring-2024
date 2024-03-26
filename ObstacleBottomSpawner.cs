using System.Collections;
using UnityEngine;

public class ObstacleBottomSpawner : MonoBehaviour
{
    public GameObject obstacleBottomObject; // The prefab to spawn
    public float spawnInterval = 2f; // Time between each spawn
    private Coroutine spawnCoroutine; // Reference to the spawning coroutine
    public Transform objectLocation;
    public float minHeight = 4.0f;
    public float maxHeight = 8.0f;
    public Rigidbody2D object2D;
    
    void Start()
    {
        object2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 2.0f, 150f);
    }

    public void Spawn()
    {
        Vector3 bottomRight = new Vector3(11.42f, -4.09f, 0); // z is set to 0 for 2D
        float randomHeight = Random.Range(minHeight, maxHeight);

        obstacleBottomObject.transform.localScale = new Vector3(
                obstacleBottomObject.transform.localScale.x,
                randomHeight,
                obstacleBottomObject.transform.localScale.z);

        Instantiate(obstacleBottomObject, bottomRight, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(obstacleBottomObject);
        }
    }
}
