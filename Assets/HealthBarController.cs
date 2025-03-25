using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    public HealthDecreaseEventSO healthEventSo;
    public GameObject healthIcon;
    public PlayerDetailsSO playerDetailSo; // Reference to the ScriptableObject

    // Start is called before the first frame update
    private void OnEnable()
    {
        healthEventSo.OnHealthDecrease += RespondToHealthDecrease;
    }


    private void OnDisable()
    {
        healthEventSo.OnHealthDecrease -= RespondToHealthDecrease;

    }

    private void RespondToHealthDecrease(int currentHealth,bool isHealthDecreased)
    {
        if (currentHealth == 0) {
            RestartLevel();

            return;
        }
        if (isHealthDecreased)


        {
            Destroy(gameObject.transform.GetChild(0).gameObject);   
        }
        else
        {
            Instantiate(healthIcon, gameObject.transform);
        }

       // Debug.Log("Script1: Health Decreased!");
    }

    void RestartLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        
    }
}
