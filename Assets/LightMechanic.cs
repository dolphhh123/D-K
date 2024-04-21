using UnityEngine;

public class LightMechanic : MonoBehaviour
{
    [SerializeField] private VignetteController _vignetteController;

    private void Start()
    {
        if (!_vignetteController)
            _vignetteController = FindObjectOfType<VignetteController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Reset Vignette");
            _vignetteController.ResetVignette();
            Destroy(this.gameObject);
        }
    }
}
