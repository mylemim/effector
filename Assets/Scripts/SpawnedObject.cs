using UnityEngine;
using System.Collections;

public class SpawnedObject : MonoBehaviour
{

    private SpawnManager spawnManager;

    // Use this for initialization
    void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
    }

    void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.NotifyOfSpawnedObjectDestroyed();
        }
    }
}

