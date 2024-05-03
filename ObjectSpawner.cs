using System;
using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] GameObject[] spawnerPrefab;
    [SerializeField] private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        
        while (canSpawn)
        {
            yield return wait;
            int rand = UnityEngine.Random.Range(0, spawnerPrefab.Length);
            GameObject objectToSpawn = spawnerPrefab[rand];
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }

    }

}