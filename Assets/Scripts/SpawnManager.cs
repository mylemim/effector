using UnityEngine;
using System.Collections;

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
        if (spawnLocations.Length>0 && instantiatedGameObjects < gameObjectsToInstantiate && Time.time - lastSpawnTime > waitingTimeBetweenSpawns)
        {
            Vector2 spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            GameObject spawnedGameObject = (GameObject)Instantiate(objectPrefab, spawnLocation, Quaternion.identity);

            //Reference the target group
            if (targetGroup)
                spawnedGameObject.transform.parent = targetGroup.transform;

            lastSpawnTime = Time.time;
            instantiatedGameObjects += 1;
        }
    }

    [ExecuteInEditMode]
    void OnValidate()
    {
        gameObjectsToInstantiate = Mathf.Abs(gameObjectsToInstantiate);
        waitingTimeBetweenSpawns = Mathf.Abs(waitingTimeBetweenSpawns);
    }
}
