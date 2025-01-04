using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Friend : MonoBehaviour
{
    public float health = 100f;

    // Common method for taking damage
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Abstract methods for specific behaviors
    public abstract void Move();

    // Common death method
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }
}