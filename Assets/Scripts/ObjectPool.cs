using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ObjectPool
{
    public GameObject ObjectPrefab;

    private Queue<GameObject> pooledObjects;

    public ObjectPool(GameObject objectPrefab)
    {
        pooledObjects = new Queue<GameObject>();
        this.ObjectPrefab = objectPrefab;
    }

	public ObjectPool(GameObject objectPrefab, int initialObjects) : this(objectPrefab)
	{
		for (int i = 0; i < initialObjects; i++)
			PoolObject (GameObject.Instantiate (objectPrefab));
	}

    public GameObject CreateObject()
    {
        GameObject createdObject;

        if (pooledObjects.Count > 0)
            createdObject = pooledObjects.Dequeue();
        else
            createdObject = GameObject.Instantiate(ObjectPrefab);

        createdObject.SetActive(true);

        return createdObject;
    }

    public void PoolObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        pooledObjects.Enqueue(gameObject);
    }

    public void ClosePool()
    {
        foreach(GameObject gObject in pooledObjects)
        {
            GameObject.Destroy(gObject);
        }
    }
}
