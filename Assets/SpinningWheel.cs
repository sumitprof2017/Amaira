using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    public float normalSpeed = 50f;  // Normal rotation speed
    public float boostedSpeed = 120; // Maximum boosted speed
    public float acceleration = 10f;  // How fast it speeds up
    public float deceleration = 5f;   // How fast it slows down

    private Rigidbody2D rb;
    private float targetSpeed;
    private bool isPlayerOnWheel = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetSpeed = normalSpeed;
    }

    void FixedUpdate()
    {
        // Smoothly change rotation speed
        float currentSpeed = Mathf.Lerp(rb.angularVelocity, targetSpeed, Time.fixedDeltaTime * (isPlayerOnWheel ? acceleration : deceleration));
        rb.angularVelocity = currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnWheel = true;
            targetSpeed = boostedSpeed;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnWheel = false;
            targetSpeed = normalSpeed;
        }
    }
}