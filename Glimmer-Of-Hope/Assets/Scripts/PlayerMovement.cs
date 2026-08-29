using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Footsteps")]
public AudioSource footstepSource;
public float footstepInterval = 0.45f;

private float footstepTimer = 0f;

    public float moveSpeed = 4f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;

    public bool verticalLookEnabled = true;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private float gravity = -9.81f;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
    }

   void Move()
{
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;

    if (controller.isGrounded && verticalVelocity < 0)
        verticalVelocity = -2f;

    verticalVelocity += gravity * Time.deltaTime;

    move.y = verticalVelocity;

    controller.Move(move * moveSpeed * Time.deltaTime);

    HandleFootsteps(x, z);
}

void HandleFootsteps(float x, float z)
{
    bool isMoving = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;

    if (isMoving && controller.isGrounded)
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0f)
        {
            footstepSource.Play();
            footstepTimer = footstepInterval;
        }
    }
    else
    {
        footstepTimer = 0f;
    }
}

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        if (verticalLookEnabled)
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

            playerCamera.localRotation =
                Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
}