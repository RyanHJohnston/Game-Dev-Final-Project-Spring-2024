using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] GameObject[] spawnerPrefab;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] float minSpawnRate = 2.0f;
    [SerializeField] float maxSpawnRate = 4.0f;
    [SerializeField] float accelerationSpawnRate = 0.1f;
    [SerializeField] float accelerationRate = 1.0f;
    private float cumulativeSpeedIncrease = 0f;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            minSpawnRate -= accelerationSpawnRate;
            maxSpawnRate -= accelerationSpawnRate;

            spawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
            WaitForSeconds wait = new WaitForSeconds(spawnRate);

            // spawn object
            int rand = UnityEngine.Random.Range(0, spawnerPrefab.Length);
            GameObject objectToSpawn = spawnerPrefab[rand];
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            ClonedObject clonedObjectScriptInstance = spawnedObject.AddComponent<ClonedObject>();
        
            // configure the movement script with increasing speed
            ObjectMovement objectMovementScriptInstance = spawnedObject.AddComponent<ObjectMovement>();
            cumulativeSpeedIncrease += accelerationRate;
            objectMovementScriptInstance.movementSpeed += cumulativeSpeedIncrease;

            yield return wait;
        }
    }
}


