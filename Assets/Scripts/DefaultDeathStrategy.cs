using UnityEngine;
using System.Collections;

public class DefaultDeathStrategy : DeathStrategy
{
    public void Die(GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
    }
}