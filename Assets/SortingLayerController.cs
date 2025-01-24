using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerController : MonoBehaviour
{
    [SerializeField] private string sortingLayerName = "Bullet"; // Set this to your desired sorting layer.
    [SerializeField] private int sortingOrder = 1; // Higher numbers render on top of lower numbers.

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // Set the sorting layer and order
            meshRenderer.sortingLayerName = sortingLayerName;
            meshRenderer.sortingOrder = sortingOrder;
        }
        else
        {
            Debug.LogWarning("MeshRenderer component not found on this GameObject.");
        }
    }
}
