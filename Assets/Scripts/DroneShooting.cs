using UnityEngine;
using System.Collections;

public class DroneShooting : MonoBehaviour
{
    [Header("Target")]
    public string TargetTag = "Player";

    [Header("Projectiles")]
    public GameObject ProjectilePrefab;

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

    private ProjectileSpawn projectileSpawn;

    void Start()
    {
        lastTimeOfFiring = Time.time;
        targetGameObject = GameObject.FindGameObjectWithTag(TargetTag);

        projectileSpawn = GameObject.Find("Projectiles").GetComponent<ProjectileSpawn>();
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

        GameObject spawnedProjectile = projectileSpawn.CreateProjectile();
        spawnedProjectile.transform.position = (Vector2)transform.position + direction * RelativeShootingDistanceFromShip;
        spawnedProjectile.transform.rotation = transform.rotation;
        Rigidbody2D projectileRigidbody = spawnedProjectile.GetComponent<Rigidbody2D>();

        projectileRigidbody.AddForce(direction * ProjectileSpeed);
        lastTimeOfFiring = Time.time;
    }
}
