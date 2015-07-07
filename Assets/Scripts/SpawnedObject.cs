using UnityEngine;
using System.Collections;

public class SpawnedObject : MonoBehaviour {

	public SpawnPoint spawnPoint;

	void OnDestroy ()
	{
		if (spawnPoint != null) {
			spawnPoint.NotifyOfSpawnedObjectDestroyed();
		}
	}
}
