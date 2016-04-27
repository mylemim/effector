using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public float waitingTimeBetweenSpawns = 5; //seconds
    public int gameObjectsToInstantiate = 10;
    /// <summary>
    /// Name of the group object the spawned objects will be stored in
    /// </summary>
    public GameObject targetGroup;
    public Vector2[] spawnLocations;

    public UnityEvent OnAllEnemiesDestroyed;

    private int instantiatedGameObjects;
    private float lastSpawnTime;

    private int destroyedGameObjects = 0;

    private ObjectPool objectPool;

    [ExecuteInEditMode]
    void OnValidate()
    {
        gameObjectsToInstantiate = Mathf.Abs(gameObjectsToInstantiate);
        waitingTimeBetweenSpawns = Mathf.Abs(waitingTimeBetweenSpawns);
    }

    private class SpawnedObjectDeathStrategy : DeathStrategy
    {
        ObjectPool pool;

        public SpawnedObjectDeathStrategy(ObjectPool pool)
        {
            this.pool = pool;
        }

        public void Die(GameObject gameObject)
        {
            pool.PoolObject(gameObject);
        }
    }

    void Start()
    {
        objectPool = new ObjectPool(objectPrefab);

        instantiatedGameObjects = 0;
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnLocations.Length > 0 && instantiatedGameObjects < gameObjectsToInstantiate && Time.time - lastSpawnTime > waitingTimeBetweenSpawns)
        {
            Vector2 spawnLocation = spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)];

            GameObject spawnedGameObject = objectPool.CreateObject();
            spawnedGameObject.transform.position = spawnLocation;
            spawnedGameObject.transform.rotation = Quaternion.identity;

            //Add reference to spawn so we can recognize when this object has been destroyed
            Health health = spawnedGameObject.GetComponent<Health>();
            if (health)
            {
                health.OnObjectDeath.AddListener(NotifyOfSpawnedObjectDestroyed);
                health.SetDeathStrategy(new SpawnedObjectDeathStrategy(objectPool));
            }
                
            //Reference the target group
            if (targetGroup)
                spawnedGameObject.transform.parent = targetGroup.transform;            

            lastSpawnTime = Time.time;
            instantiatedGameObjects += 1;
        }
    }

    public void NotifyOfSpawnedObjectDestroyed()
    {
        destroyedGameObjects++;

        if (destroyedGameObjects == gameObjectsToInstantiate)
            OnAllEnemiesDestroyed.Invoke();
    }
}
