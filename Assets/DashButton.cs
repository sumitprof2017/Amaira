using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashButton : MonoBehaviour
{
    PlayerMovement player;
    Button btnComponent;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        btnComponent = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            btnComponent.interactable = (player.canDash);
    
    }
}