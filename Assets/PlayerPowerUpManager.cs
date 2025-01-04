using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpManager : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }
  
    public void ApplySpeedBoost(GameObject player)
    {
        StartCoroutine(StartSpeedBoostCoroutine(player, 5f));
    }

    private IEnumerator StartSpeedBoostCoroutine(GameObject player,float duration)
    {
        player.GetComponent<PlayerMovement>().moveSpeed *= 2f;
        yield return new WaitForSeconds(duration);
        player.GetComponent<PlayerMovement>().moveSpeed /= 2f;

    }
    public void ApplyInvulnerabilityPwerUp(GameObject player)
    {
        StartCoroutine(InvulnerabilityPwerUpCoroutine(player, 5f, "Invulnerability"));
    }

    private IEnumerator InvulnerabilityPwerUpCoroutine(GameObject player,float duration,string layerName)
    {
        int invulnerabilityLayer = LayerMask.NameToLayer(layerName);
        player.layer = invulnerabilityLayer;
        yield return new WaitForSeconds(duration);
        int playerLayer = LayerMask.NameToLayer("Player");
        player.layer = playerLayer;

    }


    public void InvisiblePowerUp(GameObject player)
    {
        StartCoroutine(InvisibilityCoroutine(player, 8f, 0.2f, "Invulnerability"));
    }
    private IEnumerator InvisibilityCoroutine(GameObject player, float duration, float targetAlpha, string layerName)
    {

        int invulnerabilityLayer = LayerMask.NameToLayer(layerName);
        player.layer = invulnerabilityLayer;
        SpriteRenderer spriteRenderer = player.transform.GetChild(1).GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Fade out
            Color color = spriteRenderer.color;
            color.a = targetAlpha;
            spriteRenderer.color = color;


            yield return new WaitForSeconds(duration);

            // Fade in
            color.a = 1f; // Fully visible
            spriteRenderer.color = color;

            int playerLayer = LayerMask.NameToLayer("Player");
            player.layer = playerLayer;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
