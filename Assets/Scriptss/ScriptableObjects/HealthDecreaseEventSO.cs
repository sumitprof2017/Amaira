using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthDecreaseEvent", menuName = "Game/HealthDecreaseEvent")]
public class HealthDecreaseEventSO : ScriptableObject
{
    public event Action<int,bool> OnHealthDecrease; // Now takes an int parameter

    public void InvokeEvent(int currentHealth,bool isHealthDecreased)
    {
        OnHealthDecrease?.Invoke(currentHealth,isHealthDecreased);
    }
}