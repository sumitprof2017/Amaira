using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRevolveAroundParent2D : MonoBehaviour
{
    public Transform parent;
    public float speed = 10f; // Speed of revolution
    public float radius = 1f; // Fixed distance from the parent

    private float currentAngle = 0f; // Track the current angle of revolution

    void Update()
    {
        if (parent != null)
        {
            // Calculate the angle increment for this frame
            float angleIncrement = speed * Time.deltaTime;

            // Update the current angle
            currentAngle += angleIncrement;

            // Keep the angle within 0 to 360 degrees
            if (currentAngle >= 360f)
            {
                currentAngle -= 360f;
            }

            // Calculate the new position based on the current angle
            float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

            // Set the new position relative to the parent
            transform.position = parent.position + new Vector3(x, y, 0f);
        }
    }
}