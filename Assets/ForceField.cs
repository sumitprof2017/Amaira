using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    GameObject playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerTransform.transform.position;
    }
}
