using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforMovement : MonoBehaviour
{
    public float speed;
    public float moveDistance;

    private Vector3 startPos;
    private int direction = 1;
    public float offset; // Unique for each platform

    public bool isBreakable; // Determines if the platform can break

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if(!isBreakable)
        transform.position = startPos + Vector3.right * Mathf.Sin(Time.time * speed + offset) * moveDistance;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
            gameObject.layer = LayerMask.NameToLayer("UI");

        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}