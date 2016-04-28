using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject ProjectilePrefab;

    private ObjectPool objectPool;

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
        projectileBehavior.SetDeathStrategy(new SpawnedObjectDeathStrategy(objectPool));

        spawnedGameObject.transform.parent = gameObject.transform;

        return spawnedGameObject;
    }
}
