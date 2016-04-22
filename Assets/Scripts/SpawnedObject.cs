using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SpawnedObject : MonoBehaviour
{

	public UnityEvent OnSpawnedObjectDeath = new UnityEvent();

    void OnDestroy()
    {
		if(OnSpawnedObjectDeath!=null)
			OnSpawnedObjectDeath.Invoke ();
    }
}

