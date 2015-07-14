using UnityEngine;
using System.Collections;

public class ShipFiring : MonoBehaviour
{

	public GameObject ProjectilePrefab;
	[Range(0,1)]
	public float RelativeShootingDistanceFromShip = 1;
	public float ShotsPerSecond = 20f;
	public float ProjectileSpeed = 10f;

	private float lastTimeOfFiring;
	private float delayBetweenShots {
		get{
			if(ShotsPerSecond >0)
				return 1/ShotsPerSecond;
			return 0;
		}
	}

	void Start ()
	{
		lastTimeOfFiring = Time.time;
	}

	void Update ()
	{
		if (Input.GetMouseButton(0) && Time.time-lastTimeOfFiring>delayBetweenShots)
			Shoot ();
	}

	void Shoot()
	{
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 direction = Camera.main.ScreenToWorldPoint (mousePosition) - transform.position;
		direction.Normalize ();
		
		GameObject spawnedProjectile = (GameObject)Instantiate (ProjectilePrefab, 
		                                                        (Vector2)transform.position+direction*RelativeShootingDistanceFromShip, 
		                                                        transform.rotation);
		Rigidbody2D projectileRigidbody = spawnedProjectile.GetComponent<Rigidbody2D> ();
		
		projectileRigidbody.AddForce (direction * ProjectileSpeed);
		lastTimeOfFiring = Time.time;
	}
}
