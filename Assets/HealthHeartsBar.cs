using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartsBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    
    private readonly IList<HealthHeart> _hearts = new List<HealthHeart>();

    private void Start()
    {
        DrawHearts();
    }
    
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
        PlayerHealth.OnPlayerDeath += ClearHearts;
    }

    private void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        
        _hearts.Clear();
    }

    private void CreateEmptyHeart()
    {
        var heart = Instantiate(heartPrefab, transform);
        
        var healthHeart = heart.GetComponent<HealthHeart>();
        healthHeart.SetHeartImage(HeartState.Empty);
        
        _hearts.Add(healthHeart);
    }
    
    private void CreateFullHeart()
    {
        var heart = Instantiate(heartPrefab, transform);
        
        var healthHeart = heart.GetComponent<HealthHeart>();
        healthHeart.SetHeartImage(HeartState.Full);
        
        _hearts.Add(healthHeart);
    }
    
    /**
     * Each heart has 3 states: Full, Half, Empty
     * So, 8 HP = 4 Full Hearts
     */
    private void DrawHearts()
    {
        ClearHearts();

        var maxHealthRemainder = playerHealth.maxHealth % 2; // 1
        var heartsToMaxHealth = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        
        for (var i = 0; i < heartsToMaxHealth; i++)
        {
            CreateFullHeart();
        }
        
        for (var i = 0; i < _hearts.Count; i++)
        {
            var heartState = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            _hearts[i].SetHeartImage((HeartState)heartState);
        }
    }
}
