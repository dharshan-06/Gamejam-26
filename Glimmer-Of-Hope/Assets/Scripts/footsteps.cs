using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FootstepAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepClips;

    public float walkStepTime = 0.5f;
    public float sprintStepTime = 0.35f;

    private CharacterController controller;
    private float stepTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!controller.isGrounded)
            return;

        if (controller.velocity.magnitude > 0.2f)
        {
            float interval = Input.GetKey(KeyCode.LeftShift) ? sprintStepTime : walkStepTime;

            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = interval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0) return;

        int index = Random.Range(0, footstepClips.Length);
        audioSource.PlayOneShot(footstepClips[index]);
    }
}