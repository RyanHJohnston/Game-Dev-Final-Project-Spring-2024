using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
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
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            ClonedObject clonedObjectScriptInstance = spawnedObject.AddComponent<ClonedObject>();
            ObjectMovement objectMovementScriptInstance = spawnedObject.AddComponent<ObjectMovement>();
            // destroyCollisionScriptInstance.PerformAction() // optionally call method on newly attached script
            // Debug.Log("Attached DestroyOnCollision to " + spawnedObject.name);
        }
    }


}




// [SerializeField] private float spawnRate = 1f;
// [SerializeField] GameObject[] spawnerPrefab;
// [SerializeField] private bool canSpawn = true;

// void Start()
// {
//     StartCoroutine(Spawner());
// }

// private IEnumerator Spawner()
// {
//     WaitForSeconds wait = new WaitForSeconds(spawnRate);

//     while (canSpawn)
//     {
//         yield return wait;
//         int rand = UnityEngine.Random.Range(0, spawnerPrefab.Length);
//         GameObject objectToSpawn = spawnerPrefab[rand];
//         Instantiate(objectToSpawn, transform.position, Quaternion.identity);
//     }

// }
