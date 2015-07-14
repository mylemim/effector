using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float LifeTimeSeconds = 2;
	private float timeOfCreation;

	public string TargetTag = "Enemy";

	public float Damage = 10;

	void Start()
	{
		timeOfCreation = Time.time;
	}

	void Update ()
	{
		//Check if this projectile lifetime has depleted
		if(Time.time - timeOfCreation> LifeTimeSeconds)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//If we hit active game objects (world, enemy, player)
		if(!other.CompareTag("Untagged"))
			Destroy (gameObject);
		//If we hit the targeted object
		if (other.CompareTag (TargetTag)) {
			Health targetHealth = other.gameObject.GetComponent<Health>();
			targetHealth.ApplyDamage(Damage);
		}
	}
}
