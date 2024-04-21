using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;

    public void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("Player took " + amount + " damage");
        Debug.Log("Player health: " + health);
        health -= amount;
        OnPlayerDamaged?.Invoke();
        
        Debug.Log("Player health after damage: " + health);
        if (health <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
