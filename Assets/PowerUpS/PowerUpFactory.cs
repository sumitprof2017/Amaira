using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUpFactory : MonoBehaviour
{
    [Header("PowerUps")]
    public GameObject healthPowerUp,speedBoost,invisibilty, invulnurable,salt,mushroom;
    public  GameObject CreatePowerUp()
    {
        // Randomly choose a power-up
        int randomIndex = Random.Range(0, 4);
      //  randomIndex = 2;
        GameObject powerUp = null;

        switch (randomIndex)
        {
            case 1:
                powerUp = Instantiate(healthPowerUp);
                break;
            case 2:
                powerUp = Instantiate(speedBoost);
                break;
            case 3:
                powerUp = Instantiate(invisibilty);
                break;
                case 4:
                powerUp = Instantiate(invulnurable);
                break;
            case 5:
                powerUp = Instantiate(salt);
                break;
            case 6:
                powerUp = Instantiate(mushroom);
                break;
            
            default:
                Debug.LogError("Unexpected random index generated.");
                break;
        }

        return powerUp;
    } 
    
    public  GameObject CreatePowerUpRequiedPowerUps(int powerUpIndex)
    {
      
        GameObject powerUp = null;

        switch (powerUpIndex)
        {
            case 1:
                powerUp = Instantiate(healthPowerUp);
                break;
            case 2:
                powerUp = Instantiate(speedBoost);
                break;
            case 3:
                powerUp = Instantiate(invisibilty);
                break;
                case 4:
                powerUp = Instantiate(invulnurable);
                break;
            case 5:
                powerUp = Instantiate(salt);
                break; 
            case 6:
                powerUp = Instantiate(mushroom);
                break;
            default:
                Debug.LogError("Unexpected random index generated.");
                break;
        }

        return powerUp;
    }

   
}
