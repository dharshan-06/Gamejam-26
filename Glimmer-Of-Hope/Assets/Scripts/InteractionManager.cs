using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3f;

    private int keyCount = 0;
    private GameObject currentTarget;

    void Update()
    {
        DetectObject();

        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
    }

    void DetectObject()
    {
        currentTarget = null;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            currentTarget = hit.collider.gameObject;

            Debug.Log("Looking at: " + currentTarget.name);
        }
    }

void TryInteract()
{
    if (currentTarget == null)
    {
        Debug.Log("NO TARGET");
        return;
    }

    Debug.Log("CLICK TARGET: " + currentTarget.name);

    KeyItem key = currentTarget.GetComponentInParent<KeyItem>();

    if (key == null)
    {
        key = currentTarget.GetComponentInChildren<KeyItem>();
    }

    if (key != null)
    {
        keyCount++;

        Debug.Log("Key Collected! Total Keys: " + keyCount);

        Destroy(key.gameObject);

        return;
    }

    if (currentTarget.CompareTag("Door"))
    {
        if (keyCount >= 1)
        {
            Debug.Log("DOOR UNLOCKED!");
        }
        else
        {
            Debug.Log("You need a key!");
        }
    }
}
}