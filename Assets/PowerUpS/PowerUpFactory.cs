using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUpFactory : MonoBehaviour
{
    [Header("PowerUps")]
    public GameObject healthPowerUp,speedBoost,invisibilty, invulnurable;
    public  GameObject CreatePowerUp()
    {
        // Randomly choose a power-up
        int randomIndex = Random.Range(0, 4);
      //  randomIndex = 2;
        GameObject powerUp = null;

        switch (randomIndex)
        {
            case 0:
                powerUp = Instantiate(healthPowerUp);
                break;
            case 1:
                powerUp = Instantiate(speedBoost);
                break;
            case 2:
                powerUp = Instantiate(invisibilty);
                break;
                case 3:
                powerUp = Instantiate(invulnurable);
                break;
            default:
                Debug.LogError("Unexpected random index generated.");
                break;
        }

        return powerUp;
    }
}
