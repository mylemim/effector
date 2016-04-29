using System;
using UnityEngine;

public class PooledObjectDeathStrategy : DeathStrategy
{
	ObjectPool pool;

	public PooledObjectDeathStrategy(ObjectPool pool)
	{
		this.pool = pool;
	}

	public void Die(GameObject gameObject)
	{
		pool.PoolObject(gameObject);
	}
}