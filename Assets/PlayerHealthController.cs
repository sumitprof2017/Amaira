using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerPowerUpManager powerUpManager;

    public HealthDecreaseEventSO healthEventSo;


    PlayerMovement playerMovement;


    void Start()
    {
        powerUpManager = GetComponent<PlayerPowerUpManager>();
    }


    private void OnEnable()
    {
        playerMovement = GetComponent<PlayerMovement>();

        playerMovement.healthEventSo.OnHealthDecrease += RespondToHealthDecrease;
    }


    private void OnDisable()
    {
        playerMovement.healthEventSo.OnHealthDecrease -= RespondToHealthDecrease;

    }
    private void RespondToHealthDecrease(int currentHealth, bool isHealthDecreased)
    {
        if (isHealthDecreased) {
            SpriteRendererLerpVisible();
            StartCoroutine(powerUpManager.InvulnerabilityPwerUpCoroutine(gameObject, 2f, "Invulnerability"));

        }
        else
        {

        }

    }

    void SpriteRendererLerpVisible()
    {
        print("sprite renderer called");
        LeanTween.alpha(gameObject, 1f, 1f).setFrom(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
