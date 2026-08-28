using UnityEngine;

public class FlashlightLag : MonoBehaviour
{
    public float lagSpeed = 8f;

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.localRotation;
    }

    void LateUpdate()
    {
        targetRotation = Quaternion.identity;

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            lagSpeed * Time.deltaTime
        );
    }
}