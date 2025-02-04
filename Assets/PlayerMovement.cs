using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 moveVector;
    public float moveSpeed=8f;
    private bool facingRight = true;

    public Transform bulletShootPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

    }
    public void InputPlayer(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
    //jump

    public float jumpForce = 10f; // Force applied for jumping
    private bool isGrounded = true; // Tracks if the player is on the ground
    private Rigidbody2D rb; // Reference to the Rigidbody2D
    public int maxJumps = 2;
    public int jumpCount = 0;
    // Update is called once per frame

    //dash related stuffs
  

    //shoot related stuffs
    [SerializeField]
    Sprite playerBulletSprite;
    void Update()
    {
        if (!isDashing)
        {
            Vector2 movement = new Vector3(moveVector.x, 0);
            movement.Normalize();
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            if (movement.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (movement.x < 0 && facingRight)
            {
                Flip();
            }
        }


        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            BulletController.instance.ShootBullet(bulletShootPosition, facingRight);
        } if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            StartCoroutine(Shield());
        }
        if (Keyboard.current.fKey.wasPressedThisFrame && forceFieldCoolDown)
        {
            StartCoroutine(ForceField());
        }


        if (Keyboard.current.spaceKey.wasPressedThisFrame &&  jumpCount < maxJumps)
        {
            Jump();
        }
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public LayerMask enemyLayer;
    public  void Shoot()
    {
        BulletController.instance.ShootBullet(bulletShootPosition, facingRight);

    }
    private bool IsOnLayer(GameObject obj, LayerMask layerMask)
    {
        return ((1 << obj.layer) & layerMask) != 0;
    }
    [Header("DashRelated")]
    [SerializeField]
    GameObject electricity;
    public float dashForce = 20f; // Force applied for dashing
    public float dashCooldown = 1f; // Cooldown time for dashing
    public bool canDash = true; // Controls dash cooldown
    private bool isDashing = false; // Controls dash cooldown
    private float dashingTime = 0.2f;
    public TrailRenderer trailRenderer;
    public IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        trailRenderer.emitting = true;
        electricity.SetActive(true);
        yield return new WaitForSeconds(dashingTime);
        electricity.SetActive(false);

        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    [Header("ShieldRelatedStuffs")]
    [SerializeField]
    GameObject shieldObject;
    [SerializeField]
    float waitTimeForShield;
    private IEnumerator Shield()
    {
        GetComponent<PlayerMovement>().enabled = false;

        int invulnerabilityLayer = LayerMask.NameToLayer("Invulnerability");
        gameObject.layer = invulnerabilityLayer;
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(dashCooldown);
        int playerLayer = LayerMask.NameToLayer("Player");
        gameObject.layer = playerLayer;
        shieldObject.SetActive(false);
        GetComponent<PlayerMovement>().enabled = true;

    }

    [Header("ForceFieldRelatedStuffs")]
    [SerializeField]
    GameObject forceFieldObject;
    [SerializeField]
    float waitTimeForForceField;
    bool forceFieldCoolDown = true;
    private IEnumerator ForceField()
    {
        forceFieldCoolDown = false;
        int invulnerabilityLayer = LayerMask.NameToLayer("Invulnerability");
        gameObject.layer = invulnerabilityLayer;
        forceFieldObject.SetActive(true);
        yield return new WaitForSeconds(waitTimeForForceField);
        int playerLayer = LayerMask.NameToLayer("Player");
        gameObject.layer = playerLayer;
        forceFieldObject.SetActive(false);
        yield return new WaitForSeconds(waitTimeForForceField);
        forceFieldCoolDown = true;


    }

    public void DashFunc()
    {
        StartCoroutine(Dash());

    }


    void ResetDash()
    {
        isDashing = false;

        canDash = true;
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("gameobject name" + collision.gameObject.name); 
        if (collision.gameObject.CompareTag("Ground")  || collision.gameObject.CompareTag("Wall"))
        {
            jumpCount = 0;
        }
        if (IsOnLayer(collision.gameObject, enemyLayer))
        {
            Debug.Log($"Enemy layer is");
            SceneManager.LoadScene("FirstScene");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invert the X scale
        transform.localScale = scale;
    }
}
