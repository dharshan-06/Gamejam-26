using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Developer Cheat")]
    public KeyCode completeKeysKey = KeyCode.F9;

    public Camera playerCamera;
    public float interactionDistance = 3f;
    public KeyCounter keyCounter;

    public int requiredKeys = 1;

    private int keyCount = 0;
    private GameObject currentTarget;
    public LevelTransition levelTransition;

    [Header("Key Pickup SFX")]
    public AudioSource keyPickupSound;

    void Update()
    {
        DetectObject();

        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }

        if (Input.GetKeyDown(completeKeysKey))
{
    keyCount = requiredKeys;

    keyCounter.CompleteKeys();

    Debug.Log("CHEAT ACTIVATED: Required keys completed!");
}
    }

    void DetectObject()
    {
        currentTarget = null;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            currentTarget = hit.collider.gameObject;
        }
    }

    void TryInteract()
    {
        if (currentTarget == null)
            return;

        KeyItem key = currentTarget.GetComponentInParent<KeyItem>();

        if (key == null)
        {
            key = currentTarget.GetComponentInChildren<KeyItem>();
        }

        if (key != null)
        {
            keyCount++;

            keyCounter.AddKey();

            if (keyPickupSound != null)
            {
                keyPickupSound.Play();
            }

            Debug.Log("Key Collected! Total Keys: " + keyCount);

            Destroy(key.gameObject);

            return;
        }

        if (currentTarget.CompareTag("Door"))
        {
            if (keyCount >= requiredKeys)
            {
                Debug.Log("DOOR UNLOCKED!");

                levelTransition.GoToNextLevel();
            }
            else
            {
                Debug.Log("Not Enough Keys");
            }
        }
    }
}