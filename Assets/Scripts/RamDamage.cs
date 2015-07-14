using UnityEngine;
using System.Collections;

public class RamDamage : MonoBehaviour {

	public string TargetTag = "Enemy";
	
	public float Damage = 10;

	void OnCollisionEnter2D (Collision2D collision)
	{
		GameObject other = collision.gameObject;
		//If we hit the targeted object
		if (other.CompareTag (TargetTag)) {
			Health targetHealth = other.gameObject.GetComponent<Health>();
			targetHealth.ApplyDamage(Damage);
		}
	}
}
