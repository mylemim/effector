using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject ProjectilePrefab;

    private ObjectPool objectPool;

    // Use this for initialization
    void Start()
    {
        objectPool = new ObjectPool(ProjectilePrefab);
    }

    // Update is called once per frame
    public GameObject CreateProjectile()
    {
        GameObject spawnedGameObject = objectPool.CreateObject();
        Projectile projectileBehavior = spawnedGameObject.GetComponent<Projectile>();
		projectileBehavior.SetDeathStrategy(new PooledObjectDeathStrategy(objectPool));

        spawnedGameObject.transform.parent = gameObject.transform;

        return spawnedGameObject;
    }
}
