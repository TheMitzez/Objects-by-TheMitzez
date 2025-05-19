using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;
    
    public Action<float> onHealthUpdate;

    public float GetHealth()
    {
        return currentHealth;
    }
    
    public Health(float maxHealth, float healthRegenRate, float currentHealth  = 100)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;

        onHealthUpdate?.Invoke(currentHealth);
    }

    public Health(float maxHealth)
    {
        this.maxHealth=maxHealth;
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenRate * Time.deltaTime);
    }

    public Health()
    {

    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + value);
        onHealthUpdate?.Invoke(currentHealth);
    }

    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
        onHealthUpdate?.Invoke(currentHealth);
    }
}
