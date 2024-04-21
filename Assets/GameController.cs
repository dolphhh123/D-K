using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private WinScreenController winScreen;
    [SerializeField] private GameOverScreenController gameOverScreen;
    [SerializeField] private PlayerHealth playerHealth;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandleDeath;
        PlayerHealth.OnPlayerDamaged += HandleDamage;
    }

    private void HandleDeath()
    {
        GameOver();
    }

    private void HandleDamage()
    {
        // Do something when player is damaged?
    }
    
    private void WinGame()
    {
        winScreen.Setup();
    }
    
    private void GameOver()
    {
        gameOverScreen.Setup();
    }
}
