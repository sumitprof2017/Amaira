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

       // print(SaveSystem.LoadPlayerData(playerDetailSo));

        if (SaveSystem.LoadPlayerData(playerDetailSo) != Vector3.zero)
        {
            playerAmaira.transform.position = SaveSystem.LoadPlayerData(playerDetailSo);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
