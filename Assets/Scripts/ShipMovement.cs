using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	private Rigidbody2D rigidBody;
	public float ThrustSpeed = 4f;

	// Use this for initialization
	void Start ()
	{
		rigidBody = this.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		ApplyThrust ();
		RotateTowardsMouse ();
	}

	void ApplyThrust ()
	{
		//Thrust forward/backward
		if (Input.GetKey (KeyCode.W))
			rigidBody.AddRelativeForce (new Vector2 (0, ThrustSpeed));
		else
			if (Input.GetKey (KeyCode.S))
			rigidBody.AddRelativeForce (new Vector2 (0, -ThrustSpeed));

		//Thrust sideways
		if (Input.GetKey (KeyCode.D))
			rigidBody.AddRelativeForce (new Vector2 (ThrustSpeed, 0));
		else
			if (Input.GetKey (KeyCode.A))
			rigidBody.AddRelativeForce (new Vector2 (-ThrustSpeed, 0));
	}

	void RotateTowardsMouse ()
	{
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 positionDifference = Camera.main.ScreenToWorldPoint (mousePosition)-transform.position;

		float rotationAmount = Mathf.Atan2(positionDifference.y, positionDifference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount - 90);
	}
}
