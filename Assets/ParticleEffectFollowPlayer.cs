using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectFollowPlayer : MonoBehaviour
{
    public Transform player;
    private float threshold = 5f; // How far the player moves before updating snow position

    void Update()
    {
        // Only update if the player moves too far from the current snow system
        if (Mathf.Abs(player.position.x - transform.position.x) > threshold)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}