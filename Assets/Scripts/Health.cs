using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour{
	public float HealthAmount = 10;

	public void ApplyDamage (float damage)
	{
		HealthAmount -= damage;
		if (HealthAmount <= 0)
			Die ();
	}

	public virtual void Die()
	{
		Destroy (gameObject);
	}
}
