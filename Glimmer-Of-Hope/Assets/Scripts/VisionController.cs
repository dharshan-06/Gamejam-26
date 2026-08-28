using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Light spotlight;
    public GameObject blurryVision;
    public PlayerMovement playerMovement;

    [Header("Audio")]
    public AudioSource torchFuzzSound;
    public AudioSource torchButtonSound;

    [Header("Timing")]
    public float torchMinTime = 3f;
    public float torchMaxTime = 7f;
    public float blurryTime = 5f;

    [Header("Lighting")]
    public float torchEnvironmentIntensity = 0.1f;
    public float torchReflectionIntensity = 0.1f;

    public float blurryEnvironmentIntensity = 0.25f;
    public float blurryReflectionIntensity = 0.45f;

    void Start()
    {
        StartCoroutine(VisionCycle());
    }

    System.Collections.IEnumerator VisionCycle()
    {
        while (true)
        {
            SetTorchVision();

            float torchTime = Random.Range(torchMinTime, torchMaxTime);
            yield return new WaitForSeconds(torchTime);

            SetBlurryVision();

            yield return new WaitForSeconds(blurryTime);
        }
    }
void SetTorchVision()
{
    spotlight.enabled = true;
    blurryVision.SetActive(false);

    RenderSettings.ambientIntensity = torchEnvironmentIntensity;
    RenderSettings.reflectionIntensity = torchReflectionIntensity;

    playerMovement.verticalLookEnabled = true;

    torchButtonSound.Stop();

    if (!torchFuzzSound.isPlaying)
        torchFuzzSound.Play();
}

 void SetBlurryVision()
{
    spotlight.enabled = false;
    blurryVision.SetActive(true);

    RenderSettings.ambientIntensity = blurryEnvironmentIntensity;
    RenderSettings.reflectionIntensity = blurryReflectionIntensity;

    playerMovement.verticalLookEnabled = false;

    torchFuzzSound.Stop();

    torchButtonSound.Stop();
    torchButtonSound.Play();
}
}