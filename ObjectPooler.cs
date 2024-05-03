using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    public GameObject pooledObjectPrefab;
    public int poolSize = 5;
    private List<GameObject> pooledObjects;

    void Awake()
    {
        Instance = this;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObjectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;  // Return null if all objects are currently active
    }
}