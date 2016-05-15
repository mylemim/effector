using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public float WaitingTimeBetweenSpawns = 5;
    //seconds
    public int GameObjectsToInstantiate = 10;
    public string HolderObjectName = "Enemies";

    public Vector2[] SpawnLocations;

    public UnityEvent OnAllEnemiesDestroyed;

    private int instantiatedGameObjects;
    private float lastSpawnTime;

    private int destroyedGameObjects;

    private ObjectPool objectPool;

    private GameObject spawnedObjectHolder;

    [ExecuteInEditMode]
    void OnValidate()
    {
        GameObjectsToInstantiate = Mathf.Abs(GameObjectsToInstantiate);
        WaitingTimeBetweenSpawns = Mathf.Abs(WaitingTimeBetweenSpawns);
    }

    public void Start()
    {
        instantiatedGameObjects = 0;
        lastSpawnTime = 0;
        destroyedGameObjects = 0;

		spawnedObjectHolder = GameObject.Find(HolderObjectName);
		if (spawnedObjectHolder == null)
			spawnedObjectHolder = new GameObject(HolderObjectName);

		objectPool = new ObjectPool(ObjectPrefab);
		for (int i = 0; i < GameObjectsToInstantiate; i++)
			objectPool.PoolObject (CreateObject ());
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnLocations.Length > 0 && instantiatedGameObjects < GameObjectsToInstantiate && Time.timeSinceLevelLoad - lastSpawnTime > WaitingTimeBetweenSpawns)
        {
            SpawnObject();
        }
    }
		
    public GameObject CreateObject()
    {
        Vector2 spawnLocation = SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)];
        GameObject spawnedGameObject = objectPool.CreateObject();
        spawnedGameObject.transform.position = spawnLocation;
        spawnedGameObject.transform.rotation = Quaternion.identity;

        //Reference the target group
        spawnedGameObject.transform.SetParent(spawnedObjectHolder.transform);

        return spawnedGameObject;
    }

    public GameObject SpawnObject()
    {
        GameObject spawnedGameObject = CreateObject();

        //Add reference to spawn so we can recognize when this object has been destroyed
        Health health = spawnedGameObject.GetComponent<Health>();
        if (health)
        {
            health.OnObjectDeath.AddListener(NotifyOfSpawnedObjectDestroyed);
            health.SetDeathStrategy(new PooledObjectDeathStrategy(objectPool));
        }

        lastSpawnTime = Time.timeSinceLevelLoad;
        instantiatedGameObjects += 1;

        return spawnedGameObject;
    }

    public void NotifyOfSpawnedObjectDestroyed()
    {
        destroyedGameObjects++;

		if (destroyedGameObjects == GameObjectsToInstantiate) {
			OnAllEnemiesDestroyed.Invoke ();
		}
    }
}
