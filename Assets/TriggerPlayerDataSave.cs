using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPlayerDataSave : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkpointNumber; // Unique checkpoint number
    public PlayerDetailsSO playerDetailSo; // Reference to the ScriptableObject
    public bool isTriggered = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered) // Make sure Player has "Player" tag
        {
            isTriggered = true;
            playerDetailSo.sceneName = SceneManager.GetActiveScene().name;
            playerDetailSo.checkpointNumber = checkpointNumber;
            if (gameObject.transform.GetChild(0) != null)
            {
                playerDetailSo.checkpointPosition = gameObject.transform.GetChild(0).transform.position;
            }
            SaveSystem.SavePlayerData(playerDetailSo);

            Debug.Log($"Checkpoint {checkpointNumber} saved in {playerDetailSo.sceneName}");
        }
    }

  

}
