using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject Bullet;

    public Queue<GameObject> bulletQueue = new Queue<GameObject>();
    public static BulletController instance;
    [SerializeField]
    Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 100; i++)
        {
            Instantiate(Bullet);
            bulletQueue.Enqueue(Bullet);
        }
    }
    public float bulletSpeed = 20f;
    public void ShootBullet(Transform FirePoint,bool isFacingRight, Sprite newSprite = null)
    {
        if (bulletQueue.Count > 0)
        {
            GameObject bullet = bulletQueue.Dequeue();
            bullet.transform.position = FirePoint.position; // Set bullet position
            bullet.transform.rotation = FirePoint.rotation; // Match fire point rotation
            bullet.SetActive(true); // Activate the bullet

            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) return;

            // If no sprite is provided, use the default sprite
            spriteRenderer.sprite = newSprite != null ? newSprite : defaultSprite;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float direction = isFacingRight ? 1 : -1; // Determine direction
                rb.velocity = new Vector2(direction * bulletSpeed, 0f); // Apply velocity
            }
            // Add functionality to restore the bullet after a time (or collision)
            StartCoroutine(RestoreBullet(bullet, 4f)); // Deactivates after 2 seconds
        }
        else
        {
            Debug.Log("No bullets available in the pool!");
        }
    }
    
    public void ShootBulletFromEnemyToPlayer(Transform firePoint, Transform playerTransform,float scaleMultiplier = 2, Sprite newSprite = null)
    {
        if (bulletQueue.Count > 0)
        {
            GameObject bullet = bulletQueue.Dequeue();
            int newLayer = LayerMask.NameToLayer("EnemyBullet");
            bullet.layer = newLayer;
            bullet.transform.position = firePoint.position; // Set bullet position
            bullet.transform.rotation = firePoint.rotation; // Match fire point rotation
            bullet.SetActive(true); // Activate the bullet
            //sprite related stuffs
            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) return;

            // If no sprite is provided, use the default sprite
            spriteRenderer.sprite = newSprite != null ? newSprite : defaultSprite;


            // bullet.transform.localScale = bullet.transform.localScale* scaleMultiplier;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate direction from fire point to player
                Vector2 direction = (playerTransform.position - firePoint.position).normalized;
                rb.velocity = direction * bulletSpeed; // Apply velocity
            }
          //  bullet.gameObject.transform.localScale = bullet.gameObject.transform.localScale * 2;
            // Restore the bullet after a delay
            StartCoroutine(RestoreBullet(bullet, 3f)); // Deactivates after 6 seconds
        }
        else
        {
            Debug.Log("No bullets available in the pool!");
        }
    }

    private IEnumerator RestoreBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bullet.SetActive(false); // Deactivate the bullet
        int newLayer = LayerMask.NameToLayer("Bullet");                                    // bullet.transform.localScale = bullet.transform.localScale* scaleMultiplier;
        bullet.layer = newLayer;
        bullet.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        if (!bulletQueue.Contains(bullet)) { 
            bulletQueue.Enqueue(bullet);
        }
        // bullet.gameObject.LeanScale(new Vector3(0.35f, 0.35f, 0.35f), 0f);
         // Return it to the pool
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
