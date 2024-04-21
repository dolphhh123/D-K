using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player Not Found!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = newPosition;
            
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}