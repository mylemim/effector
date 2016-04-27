using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ObjectPool
{
    public GameObject objectPrefab;

    private Queue<GameObject> pooledObjects;

    public ObjectPool(GameObject objectPrefab)
    {
        pooledObjects = new Queue<GameObject>();
        this.objectPrefab = objectPrefab;
    }

    public GameObject CreateObject()
    {
        GameObject createdObject;

        if (pooledObjects.Count > 0)
        {
            createdObject = pooledObjects.Dequeue();
            createdObject.SetActive(true);
        }
        else
            createdObject = GameObject.Instantiate(objectPrefab);

        return createdObject;
    }

    public void PoolObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pooledObjects.Enqueue(gameObject);
    }
}
