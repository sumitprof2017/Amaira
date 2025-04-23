using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float fadeDuration = 1f;
    private SpriteRenderer sr;

    void OnEnable()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogWarning("No SpriteRenderer found on laser object.");
            return;
        }

        // Instantly set alpha to 1
        Color color = sr.color;
        color.a = 1f;
        sr.color = color;

        // Fade alpha to 0 over fadeDuration
        LeanTween.value(gameObject, 1f, 0f, fadeDuration)
            .setOnUpdate((float alpha) =>
            {
                Color c = sr.color;
                c.a = alpha;
                sr.color = c;
            });
    }
}
