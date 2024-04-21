using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    public float decayRate;
    
    [SerializeField] private float vignetteStrength;
    [SerializeField] private PostProcessVolume postProcessVolume;
    
    private Vignette vignette;

    private void Start()
    {
        if (postProcessVolume.profile.TryGetSettings(out Vignette vignette))
        {
            this.vignette = vignette;
            vignetteStrength = vignette.intensity.value;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (vignette != null && vignetteStrength <= 1)
        {
            vignette.intensity.value = vignetteStrength += (decayRate * Time.deltaTime);
        }
    }

    public void ResetVignette()
    {
        vignetteStrength = 0;
    }
}
