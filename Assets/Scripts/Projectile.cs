using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class Projectile : MonoBehaviour
{
    public float LifeTimeSeconds = 2;
    private float timeOfCreation;

    public float Damage = 10;

    private DeathStrategy deathStrategy = new DefaultDeathStrategy();

    public void SetDeathStrategy(DeathStrategy deathStrategy)
    {
        this.deathStrategy = deathStrategy;
    }

    void Start()
    {
        timeOfCreation = Time.time;
    }

    void Update()
    {
        //Check if this projectile lifetime has depleted
        if (Time.time - timeOfCreation > LifeTimeSeconds)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If we hit active game objects (world, enemy, player)
        if (!other.CompareTag("Untagged"))
        {
            deathStrategy.Die(gameObject);
        }

        //If we hit an object with health
        Health targetHealth = other.gameObject.GetComponent<Health>();
        if (targetHealth)
            targetHealth.ApplyDamage(Damage);
    }
}
