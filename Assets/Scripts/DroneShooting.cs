using UnityEngine;
using System.Collections;

public class DroneShooting : MonoBehaviour
{
    public string TargetTag = "Player";
    private GameObject targetGameObject;

    public GameObject ProjectilePrefab;
    [Range(0, 1)]
    public float RelativeShootingDistanceFromShip = 1;
    public float ShotsPerSecond = 20f;
    public float ProjectileSpeed = 10f;

    private float lastTimeOfFiring;
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

        projectileRigidbody.AddForce(direction * ProjectileSpeed);
        lastTimeOfFiring = Time.time;
    }
}
