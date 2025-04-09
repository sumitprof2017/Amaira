using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Enemy
{
    public override void Move()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public Vector3 normalScale = new Vector3(1, 1, 1); // Normal scale of the object
    public Vector3 targetScale = new Vector3(1, 2, 1); // Target scale on Y-axis (for example, double size in Y)
    public float scaleSpeed = 2.0f; // Speed of scaling
    public float moveSpeed = 2.0f; // Speed of movement in Y

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(ScaleAndMoveLoop());
    }

    IEnumerator ScaleAndMoveLoop()
    {
        // First scale the object back to its normal size
        yield return StartCoroutine(ScaleToNormal());

        // Then, scale in the Y-axis and move the position in Y
        yield return StartCoroutine(ScaleAndMoveY());
    }

    IEnumerator ScaleToNormal()
    {
        Vector3 startScale = transform.localScale;
        float time = 0;

        while (time < 1)
        {
            transform.localScale = Vector3.Lerp(startScale, normalScale, time);
            time += Time.deltaTime * scaleSpeed;
            yield return null;
        }
        transform.localScale = normalScale;
    }

    IEnumerator ScaleAndMoveY()
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetPosition = new Vector3(transform.position.x, initialPosition.y + 5f, transform.position.z); // Example of moving up by 5 units
        float time = 0;

        while (time < 1)
        {
            // Scale only on Y
            transform.localScale = new Vector3(startScale.x, Mathf.Lerp(startScale.y, targetScale.y, time), startScale.z);
            // Move only on Y
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPosition.y, time), transform.position.z);

            time += Time.deltaTime * scaleSpeed;
            yield return null;
        }

        // Final scale and position
        transform.localScale = new Vector3(startScale.x, targetScale.y, startScale.z);
        transform.position = targetPosition;
    }
}