using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health = 100f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
        else
        {
            Debug.LogError("No SpriteRenderer found on the GameObject.");
        }
    }
    // Common method for taking damage
    public virtual void TakeDamage(float damage)
    {
        print("damage taken"+damage);
        health -= damage;
        ChangeColor();
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void ChangeColor()
    {
        if (spriteRenderer != null)
        {
            // Change to transparent
            LeanTween.value(gameObject, UpdateColor, originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0f), 0.15f)
                .setOnComplete(() =>
                {
                    // Change back to original
                    LeanTween.value(gameObject, UpdateColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0f), originalColor, 0.15f);
                });
        }
    }
    private void UpdateColor(Color color)
    {
        spriteRenderer.color = color;
    }

    // Abstract methods for specific behaviors
    public abstract void Move();

    // Common death method
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
       // Destroy(gameObject);
    }
}