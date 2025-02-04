using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : Enemy
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public LayerMask wallLayer, forceFieldLayer; // Layer for the player
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
        if (IsOnLayer(collision.gameObject, wallLayer) || IsOnLayer(collision.gameObject, forceFieldLayer))
        {
            Debug.Log($"Buffalo hit a wall: {collision.gameObject.name}");
            Flip();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            TakeDamage(10f);
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

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAttack());        
    }
    [Header("EnemyAttackRelated")]
    public Transform firePosition;
    public PlayerMovement player;
    IEnumerator StartAttack()
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(2f);

        }
    }

    public void Shoot()
    {
        if(Vector2.Distance(firePosition.position, player.transform.position) < 5)
            BulletController.instance.ShootBulletFromEnemyToPlayer(firePosition, player.transform,4);
    }
    // Update is called once per frame

}
