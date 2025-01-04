using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBoulder1 : Enemy
{
    public override void Move()
    {
    }
    [SerializeField]
    float rollSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    bool IsGrounded()
    {
        return GetComponent<Rigidbody2D>().velocity.y == 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collison gameobject name"+collision.gameObject.name);    
        // Check if the buffalo collided with the player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            print("collision is bullet called");

            TakeDamage(50f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            gameObject.transform.position -= new Vector3(rollSpeed, 0, 0);
        }
        gameObject.transform.Rotate(0,0,3f);
    }
}
