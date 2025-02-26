using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    private int difficultyLevel = 0;  // Current difficulty level
    private const int maxDifficulty = 2;  // Maximum difficulty increases
    public float difficultyMultiplier = 1.0f;  // Default multiplier

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficultyLevel(float difficultyMultiplier)
    {
        this.difficultyMultiplier = difficultyMultiplier;  // Increase speed multiplier
        UpdateEnemySpeeds();

    }

 

    private void UpdateEnemySpeeds()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>(); // Get all enemies
        foreach (Enemy enemy in enemies)
        {
            enemy.difficultyMultiplier = difficultyMultiplier; // Apply new speed
        }
    }
}