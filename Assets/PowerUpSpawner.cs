using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
   public static PowerUpSpawner instance;
    void Start()
    {
        instance = this;
    }
    [SerializeField]
    PowerUpFactory powerUpFactory;
    // Update is called once per frame
    public void SpawnPowerUps(Vector2 spawnPosition)
    {
            // Create a power-up using the factory
            GameObject powerUp = powerUpFactory.CreatePowerUp();
            // Set power-up's position
            powerUp.transform.position = spawnPosition;

     }
    }

