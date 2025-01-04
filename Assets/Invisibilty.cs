using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilty : PowerUp
{
    public override void Apply(PlayerMovement player)
    {
        throw new System.NotImplementedException();
        
    }

    public override string GetPowerUpName()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            collision.gameObject.GetComponent<PlayerPowerUpManager>().InvisiblePowerUp(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
