using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    
    public void RestartGame()
    {
        gameObject.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
