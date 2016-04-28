using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{
    public float StartingHealthAmount = 10;
    protected float healthAmount;

    public OnHealthChangedEvent OnHealthChanged;
    public UnityEvent OnObjectDeath;

    private DeathStrategy deathStrategy = new DefaultDeathStrategy();

    [Serializable]
    public class OnHealthChangedEvent : UnityEvent<int> { };

    public void SetDeathStrategy(DeathStrategy deathStrategy)
    {
        this.deathStrategy = deathStrategy;
    }

    protected virtual void Start()
    {
        healthAmount = StartingHealthAmount;
        OnHealthChanged.Invoke((int)this.healthAmount);
    }

    public virtual void ApplyDamage(float damage)
    {
        healthAmount -= damage;
        if (healthAmount <= 0)
        {
            healthAmount = 0;
            Die();
        }

        OnHealthChanged.Invoke((int)this.healthAmount);
    }

    public virtual void Die()
    {
        //Notify all listeners about the death
        OnObjectDeath.Invoke();

        deathStrategy.Die(gameObject);

        //Clear all listeners for reusability of the object in the pool
        OnHealthChanged.RemoveAllListeners();
        OnObjectDeath.RemoveAllListeners();
    }
}
