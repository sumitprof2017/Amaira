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
    private int jumpCount = 0;
    // Update is called once per frame

    //dash related stuffs
    public float dashForce = 20f; // Force applied for dashing
    public float dashCooldown = 1f; // Cooldown time for dashing
    private bool canDash = true; // Controls dash cooldown
    private bool isDashing = false; // Controls dash cooldown
    private float dashingTime = 0.2f;
    public TrailRenderer trailRenderer;

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
        }
 

        if (Keyboard.current.spaceKey.wasPressedThisFrame &&  jumpCount < maxJumps)
        {
            Jump();
        }
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame && canDash)
        {
            StartCoroutine(Dash());
           // Dash();
        }
    }
    public LayerMask enemyLayer;
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the buffalo collided with the player
        if (IsOnLayer(collision.gameObject, enemyLayer))
        {
            Debug.Log($"Enemy layer is");
            SceneManager.LoadScene("FirstScene");
        }
    }*/
    private bool IsOnLayer(GameObject obj, LayerMask layerMask)
    {
        return ((1 << obj.layer) & layerMask) != 0;
    }

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

  /*  void Dash()
    {
        // Calculate the dash direction based on facing direction
        float dashDirection = facingRight ? 1f : -1f;

        // Determine the new position
        Vector3 dashPosition = transform.position + new Vector3(dashDirection * dashForce, 0, 0);

        // Set the new position directly
        transform.position = dashPosition;

        // Start dash cooldown
        canDash = false;
        Invoke(nameof(ResetDash), dashCooldown); // Reset dash after cooldown
    }*/
   /* void Dash()
    {
        isDashing = true;
        // Apply an instantaneous force in the direction the player is facing
        float dashDirection = facingRight ? 1f : -1f;
        rb.AddForce(new Vector2(dashDirection * dashForce, 0), ForceMode2D.Impulse);

        // Start dash cooldown
        canDash = false;
        Invoke(nameof(ResetDash), dashCooldown); // Reset dash after cooldown
    }*/

    void ResetDash()
    {
        isDashing = false;

        canDash = true;
    }
    void Jump()
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
