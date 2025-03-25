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
    bool isGrounded = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the buffalo collided with the player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            print("collision is bullet called");

            TakeDamage(50f);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() || isGrounded)
        {
           // gameObject.transform.position -= new Vector3(rollSpeed*difficultyMultiplier, 0, 0);
            gameObject.transform.position -= new Vector3(rollSpeed*1, 0, 0);
        }
        gameObject.transform.Rotate(0,0,3f);
    }
}
