using UnityEngine;
using System.Collections;

public class DroneAI : MonoBehaviour {

	public string TargetTag = "Player";
	public float Speed = 4f;

	private GameObject targetGameObject;

	private Rigidbody2D droneRigidbody;

	// Use this for initialization
	void Start () {
		targetGameObject = GameObject.FindGameObjectWithTag (TargetTag);
		droneRigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = targetGameObject.transform.position - transform.position;
		direction.Normalize ();

		float rotationAmount = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount - 90);

		droneRigidbody.AddForce (direction * Speed);
	}
}
