using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float LifeTimeSeconds = 2;
	private float timeOfCreation;

	void Start()
	{
		timeOfCreation = Time.time;
	}

	void Update ()
	{
		if(Time.time - timeOfCreation> LifeTimeSeconds)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(!other.CompareTag("Untagged"))
			Destroy (gameObject);
	}
}
