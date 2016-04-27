﻿using UnityEngine;
using System.Collections;

public class DroneShooting : MonoBehaviour
{
    private const string PROJECTILES_GROUP_NAME = "Projectiles";

    [Header("Target")]
    public string TargetTag = "Player";

    [Header("Projectiles")]
    public GameObject ProjectilePrefab;
    /// <summary>
    /// Name of the group object the spawned projectile will be stored in
    /// </summary>
    private GameObject projectileGroup;

    [Range(0, 1)]
    public float RelativeShootingDistanceFromShip = 1;
    public float ShotsPerSecond = 20f;
    public float ProjectileSpeed = 10f;

    private float lastTimeOfFiring;

    private GameObject targetGameObject;
    private float delayBetweenShots
    {
        get
        {
            if (ShotsPerSecond > 0)
                return 1 / ShotsPerSecond;
            return 0;
        }
    }

    void Start()
    {
        lastTimeOfFiring = Time.time;
        targetGameObject = GameObject.FindGameObjectWithTag(TargetTag);

        projectileGroup = GameObject.Find(PROJECTILES_GROUP_NAME);
        if (projectileGroup == null)
            projectileGroup = new GameObject(PROJECTILES_GROUP_NAME);
    }

    void Update()
    {
        if (Time.time - lastTimeOfFiring > delayBetweenShots && targetGameObject!=null)
            Shoot();
    }

    void Shoot()
    {
        Vector2 direction = targetGameObject.transform.position - transform.position;
        direction.Normalize();


        GameObject spawnedProjectile = (GameObject)Instantiate(ProjectilePrefab,
                                                                (Vector2)transform.position + direction * RelativeShootingDistanceFromShip,
                                                                transform.rotation);
        Rigidbody2D projectileRigidbody = spawnedProjectile.GetComponent<Rigidbody2D>();

        //Reference the target group
        if (projectileGroup)
            spawnedProjectile.transform.parent = projectileGroup.transform;

        projectileRigidbody.AddForce(direction * ProjectileSpeed);
        lastTimeOfFiring = Time.time;
    }
}