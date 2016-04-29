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

	public Vector2[] SpawnLocations;

	public UnityEvent OnAllEnemiesDestroyed;

	private int instantiatedGameObjects;
	private float lastSpawnTime;

	private int destroyedGameObjects = 0;

	private ObjectPool objectPool;

	[ExecuteInEditMode]
	void OnValidate ()
	{
		GameObjectsToInstantiate = Mathf.Abs (GameObjectsToInstantiate);
		WaitingTimeBetweenSpawns = Mathf.Abs (WaitingTimeBetweenSpawns);
	}

	void Start ()
	{
		objectPool = new ObjectPool (ObjectPrefab);

		for (int i = 0; i < GameObjectsToInstantiate; i++)
			objectPool.PoolObject (CreateObject ());

		instantiatedGameObjects = 0;
		lastSpawnTime = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		if (SpawnLocations.Length > 0 && instantiatedGameObjects < GameObjectsToInstantiate && Time.time - lastSpawnTime > WaitingTimeBetweenSpawns)
			SpawnObject ();
	}

	public GameObject CreateObject ()
	{
		Vector2 spawnLocation = SpawnLocations [UnityEngine.Random.Range (0, SpawnLocations.Length)];
		GameObject spawnedGameObject = objectPool.CreateObject ();
		spawnedGameObject.transform.position = spawnLocation;
		spawnedGameObject.transform.rotation = Quaternion.identity;

		//Reference the target group
		spawnedGameObject.transform.parent = gameObject.transform;

		return spawnedGameObject;
	}

	public GameObject SpawnObject(){
		GameObject spawnedGameObject = CreateObject ();

		//Add reference to spawn so we can recognize when this object has been destroyed
		Health health = spawnedGameObject.GetComponent<Health> ();
		if (health) {
			health.OnObjectDeath.AddListener (NotifyOfSpawnedObjectDestroyed);
			health.SetDeathStrategy (new PooledObjectDeathStrategy (objectPool));
		}

		lastSpawnTime = Time.time;
		instantiatedGameObjects += 1;

		return spawnedGameObject;
	}

	public void NotifyOfSpawnedObjectDestroyed ()
	{
		destroyedGameObjects++;

		if (destroyedGameObjects == GameObjectsToInstantiate)
			OnAllEnemiesDestroyed.Invoke ();
	}
}
