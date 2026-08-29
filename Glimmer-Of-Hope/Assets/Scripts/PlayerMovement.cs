using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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