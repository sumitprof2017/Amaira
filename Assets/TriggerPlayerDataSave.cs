using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPlayerDataSave : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkpointNumber; // Unique checkpoint number
    public PlayerDetailsSO playerDetailSo; // Reference to the ScriptableObject

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure Player has "Player" tag
        {
            
            playerDetailSo.sceneName = SceneManager.GetActiveScene().name;
            playerDetailSo.checkpointNumber = checkpointNumber;
            if (gameObject.transform.GetChild(0) != null)
            {
                playerDetailSo.checkpointPosition = gameObject.transform.GetChild(0).transform.position;
            }
            Debug.Log($"Checkpoint {checkpointNumber} saved in {playerDetailSo.sceneName}");
        }
    }

  

}
