using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class PlayerHealth : Health {

	public string HealthCounterName = "Health Counter";

	public OnHealthChangedEvent OnHealthChanged;
	public UnityEvent OnPlayerDeath;

	[Serializable]
	public class OnHealthChangedEvent : UnityEvent<int>{};

	protected override void Start(){
		base.Start ();
		OnHealthChanged.Invoke ((int)this.healthAmount);
	}

	public override void ApplyDamage (float damage)
	{
		base.ApplyDamage (damage);
		OnHealthChanged.Invoke ((int)this.healthAmount);
	}

	public override void Die(){
		OnPlayerDeath.Invoke ();
        base.Die();
    }

}
