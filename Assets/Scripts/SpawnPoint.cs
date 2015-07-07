using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{

	public GameObject gameObjectToInstantiate;
	public float waitingTimeBetweenSpawns = 5; //seconds
	public int maxGameObjectsToInstantiate = 10;
	private int instantiatedGameObjects;
	private float lastSpawnTime;

	// Use this for initialization
	void Start ()
	{
		instantiatedGameObjects = 0;
		lastSpawnTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (instantiatedGameObjects < maxGameObjectsToInstantiate && Time.time - lastSpawnTime > waitingTimeBetweenSpawns) {
			GameObject spawnedGameObject = (GameObject) Instantiate(gameObjectToInstantiate, gameObject.transform.position, Quaternion.identity);
			spawnedGameObject.AddComponent<SpawnedObject>();
			SpawnedObject spawnedObjectBehavior = spawnedGameObject.GetComponent<SpawnedObject>();
			spawnedObjectBehavior.spawnPoint= this;

			lastSpawnTime = Time.time;
			instantiatedGameObjects += 1;
		}
	}

	public void NotifyOfSpawnedObjectDestroyed()
	{
		instantiatedGameObjects -= 1;
		instantiatedGameObjects = Mathf.Max (instantiatedGameObjects, 0);
	}
}
