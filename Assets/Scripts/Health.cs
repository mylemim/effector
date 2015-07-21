using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour{
	public float StartingHealthAmount = 10;
	protected float healthAmount;

	protected virtual void Start(){
		healthAmount = StartingHealthAmount;
	}

	public virtual void ApplyDamage (float damage)
	{
		healthAmount -= damage;
		if (healthAmount <= 0)
			Die ();
	}

	public virtual void Die()
	{
		Destroy (gameObject);
	}
}
