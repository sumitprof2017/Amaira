using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMomoMania : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerDetailsSO playerDetailSo;

    GameObject playerAmaira;
    void Start()
    {

        playerAmaira = GameObject.FindObjectOfType<PlayerMovement>().gameObject; 
          if(playerDetailSo.checkpointPosition != Vector3.zero)
        {
            playerAmaira.transform.position = playerDetailSo.checkpointPosition;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
