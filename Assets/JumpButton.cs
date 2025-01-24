using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    // Start is called before the first frame update
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

        btnComponent.interactable = (player.jumpCount < 2);
    }
}
