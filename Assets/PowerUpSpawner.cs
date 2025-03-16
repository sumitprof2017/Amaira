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
    public void SpawnPowerUps(Vector2 spawnPosition,int staticPowerUp = 0)
    {
            // Create a power-up using the factory
            if(staticPowerUp == 0)
        {
            //get randomPowerUp
            GameObject powerUp = powerUpFactory.CreatePowerUp();
            powerUp.transform.position = spawnPosition;

        }
        else
        {
            GameObject powerUp = powerUpFactory.CreatePowerUpRequiedPowerUps(staticPowerUp);
            powerUp.transform.position = spawnPosition;
        }
        // Set power-up's position

    }

    public void SpawnRequiredPowerUp(Vector2 spawnPosition)
    {
        GameObject powerUp = powerUpFactory.CreatePowerUp();
        // Set power-up's position
        powerUp.transform.position = spawnPosition;
    }
}

