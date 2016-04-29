using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject ProjectilePrefab;

    private ObjectPool objectPool;

	public int InitialCachedProjectiles = 100;

    // Use this for initialization
    void Start()
    {
		objectPool = new ObjectPool(ProjectilePrefab);

		for (int i = 0; i < InitialCachedProjectiles; i++)
			objectPool.PoolObject (CreateProjectile ());
    }
		
    public GameObject CreateProjectile()
    {
        GameObject spawnedGameObject = objectPool.CreateObject();
        spawnedGameObject.transform.parent = gameObject.transform;
        return spawnedGameObject;
    }

	public GameObject SpawnProjectile(){
		GameObject spawnedGameObject = CreateProjectile ();
		Projectile projectileBehavior = spawnedGameObject.GetComponent<Projectile>();
		projectileBehavior.SetDeathStrategy(new PooledObjectDeathStrategy(objectPool));
		return spawnedGameObject;
	}
}
