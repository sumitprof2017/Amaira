using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        gameObject.SetActive(false);
    }
}
