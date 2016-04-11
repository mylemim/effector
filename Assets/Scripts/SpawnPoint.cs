using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;
    public float waitingTimeBetweenSpawns = 5; //seconds
    public int maxGameObjectsToInstantiate = 10;
    //Name of the group object the spawned objects will be stored in
    public GameObject targetGroup;
    public Vector2 spawnLocation;

    private int instantiatedGameObjects;
    private float lastSpawnTime;

    // Use this for initialization
    void Start()
    {
        instantiatedGameObjects = 0;
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedGameObjects < maxGameObjectsToInstantiate && Time.time - lastSpawnTime > waitingTimeBetweenSpawns)
        {
            GameObject spawnedGameObject = (GameObject)Instantiate(gameObjectToInstantiate, spawnLocation, Quaternion.identity);

            //Reference the target group
            if (targetGroup)
                spawnedGameObject.transform.parent = targetGroup.transform;

            //Add reference to spawn so we can recognize when this object has been destroyed
            spawnedGameObject.AddComponent<SpawnedObject>();
            SpawnedObject spawnedObjectBehavior = spawnedGameObject.GetComponent<SpawnedObject>();
            spawnedObjectBehavior.spawnPoint = this;

            lastSpawnTime = Time.time;
            instantiatedGameObjects += 1;
        }
    }

    public void NotifyOfSpawnedObjectDestroyed()
    {
        instantiatedGameObjects -= 1;
        instantiatedGameObjects = Mathf.Max(instantiatedGameObjects, 0);
    }
}
