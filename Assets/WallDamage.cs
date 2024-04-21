using UnityEngine;

public class WallDamage : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("No Player Found");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            var playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(6);
        }
    }
}
