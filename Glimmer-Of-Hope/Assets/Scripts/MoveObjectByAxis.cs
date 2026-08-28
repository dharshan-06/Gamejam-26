using UnityEngine;

public class MoveObjectByAxis : MonoBehaviour
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    [Header("Movement Settings")]
    public Axis selectedAxis = Axis.X;

    [Tooltip("Distance to move in Unity units")]
    public float distance = 2f;

    [Tooltip("Movement speed in units per second")]
    public float speed = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;

        switch (selectedAxis)
        {
            case Axis.X:
                targetPosition = startPosition + Vector3.right * distance;
                break;

            case Axis.Y:
                targetPosition = startPosition + Vector3.up * distance;
                break;

            case Axis.Z:
                targetPosition = startPosition + Vector3.forward * distance;
                break;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            targetPosition = targetPosition == startPosition
                ? GetEndPosition()
                : startPosition;
        }
    }

    private Vector3 GetEndPosition()
    {
        switch (selectedAxis)
        {
            case Axis.X:
                return startPosition + Vector3.right * distance;

            case Axis.Y:
                return startPosition + Vector3.up * distance;

            case Axis.Z:
                return startPosition + Vector3.forward * distance;

            default:
                return startPosition;
        }
    }
}