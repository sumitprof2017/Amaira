using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffalo : Enemy
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public LayerMask wallLayer; // Layer for the player
    private bool movingRight = true;

    private void Update()
    {
        Move();

    }
    public float rayDistance = 0.5f;

      public override void Move()
    {
        // Move in the current direction
        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the buffalo collided with the player
        if (IsOnLayer(collision.gameObject, wallLayer))
        {
            Debug.Log($"Buffalo hit a wall: {collision.gameObject.name}");
            Flip();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) {

            TakeDamage(35f);
        }
    }
    private bool IsOnLayer(GameObject obj, LayerMask layerMask)
    {
        return ((1 << obj.layer) & layerMask) != 0;
    }

    private void Flip()
    {
        print("buffalo flip");
        movingRight = !movingRight;

        // Flip the sprite (if applicable)
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw raycast for wall detection
        Gizmos.color = Color.red;
        Vector2 rayDirection = movingRight ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(rayDirection * rayDistance));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 
}
