using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;

public class GoldCoinSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] GameObject[] spawnerPrefab;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] float minSpawnRate = 2.0f;
    [SerializeField] float maxSpawnRate = 4.0f;
    
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        spawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = UnityEngine.Random.Range(0, spawnerPrefab.Length);
            GameObject objectToSpawn = spawnerPrefab[rand];
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            ClonedObject clonedObjectScriptInstance = spawnedObject.AddComponent<ClonedObject>();
            ObjectMovement objectMovementScriptInstance = spawnedObject.AddComponent<ObjectMovement>();
        }
    }

    


}