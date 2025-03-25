using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffalo : Enemy
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public LayerMask wallLayer,forceFieldLayer; // Layer for the player
    private bool movingRight = true;
    public PlayerMovement player;

    Coroutine buffaloSpeedSpike;
    private void Update()
    {
        Move();
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < 2)
        {
            if(buffaloSpeedSpike == null)
            {
                buffaloSpeedSpike = StartCoroutine(SpeedSpike());

            }

        }
    }

    private IEnumerator SpeedSpike()
    {
        
        difficultyMultiplier = 1.4f;
        //change color
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.75f);

        GetComponent<SpriteRenderer>().color = Color.white;

        yield return new WaitForSeconds(0.75f);
        difficultyMultiplier = 1f;
        buffaloSpeedSpike = null;

    }
    public float rayDistance = 0.5f;

      public override void Move()
    {
        // Move in the current direction
        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime * difficultyMultiplier);
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (IsOnLayer(collision.gameObject, wallLayer))
         {
             Debug.Log($"Buffalo hit a wall: {collision.gameObject.name}");
             Flip();
         }
         if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
         {

             TakeDamage(35f);
         }
     }*/

    public GameObject PlatForms;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the buffalo collided with the player
        if (IsOnLayer(collision.gameObject, wallLayer)  || IsOnLayer(collision.gameObject, forceFieldLayer))
        {
          //  Debug.Log($"Buffalo hit a wall: {collision.gameObject.name}");
            Flip();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            TakeDamage(15f);

            if (health <= 0)
            {

                PlatForms.SetActive(true);
            }
        }
    }
    private bool IsOnLayer(GameObject obj, LayerMask layerMask)
    {
        return ((1 << obj.layer) & layerMask) != 0;
    }

    private void Flip()
    {
       // print("buffalo flip");
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
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
 
}
