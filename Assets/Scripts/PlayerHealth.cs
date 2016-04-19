using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

	public string HealthCounterName = "Health Counter";

	protected override void Start(){
		base.Start ();
		UpdateHealthCounter ();
	}

	public override void ApplyDamage (float damage)
	{
		base.ApplyDamage (damage);
		UpdateHealthCounter ();
	}

	private void UpdateHealthCounter(){
		GameObject healthCounter = GameObject.Find (HealthCounterName);	
		if (healthCounter != null) 
			healthCounter.GetComponent<Counter> ().Value = (int)healthAmount;
	}

	public override void Die(){
        base.Die();
        GameManager.PlayerLost();
    }

}
