using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle effect"+other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered with particle");
        }
    }
}
