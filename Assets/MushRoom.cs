using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : PowerUp
{
    public override void Apply(PlayerMovement player)
    {
        throw new System.NotImplementedException();
    }

    public override string GetPowerUpName()
    {
        throw new System.NotImplementedException();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            collision.gameObject.GetComponent<PlayerPowerUpManager>().DecreaseHealthFromMushroom(collision.gameObject,1f);
        }
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
