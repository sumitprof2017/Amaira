using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject enemyToActivate,powerUpSpawnPosition; 
    
    [SerializeField]
    bool  letPowerUpSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger is called"+gameObject.name);
        if (enemyToActivate != null) {
        
        enemyToActivate.SetActive(true);
        }
        if (letPowerUpSpawn)
        {
            PowerUpSpawner.instance.SpawnPowerUps((Vector2)(powerUpSpawnPosition.transform.position));
        }

    }
}
