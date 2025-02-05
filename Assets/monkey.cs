using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : Enemy
{
    Rigidbody2D rb;
    public float forceY = 10f;
    public bool letMonkeyAttack = false;
    public override void Move()
    {


    }

    void Jump()
    {

    }
    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          rb.AddForce(new Vector2(0, forceY), ForceMode2D.Impulse);
          if (letMonkeyAttack)
              Shoot();
          if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
          {

              TakeDamage(50f);
          }
      }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(new Vector2(0, forceY), ForceMode2D.Impulse);
        if (letMonkeyAttack)
            Shoot();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {

            TakeDamage(50f);
        }

    }
    public Transform firePosition;
    public PlayerMovement player;
    public Sprite bananaImage;
    public void Shoot()
    {
        if (Vector2.Distance(firePosition.position, player.transform.position) < 5)
        {

            AudioController.instance.PlayerEnemyAttackAudio(audioCliptoAttack);
            BulletController.instance.ShootBulletFromEnemyToPlayer(firePosition, player.transform, 2, bananaImage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        letMonkeyAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
