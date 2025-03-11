using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : PowerUp
{
    public override void Apply(PlayerMovement player)
    {
        print("health increased");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            collision.gameObject.GetComponent<PlayerPowerUpManager>().IncreaseHealth();
        }
    }
    public override string GetPowerUpName()
    {
        throw new System.NotImplementedException();
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
