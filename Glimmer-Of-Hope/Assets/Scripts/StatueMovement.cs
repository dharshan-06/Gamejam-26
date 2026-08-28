using UnityEngine;
using System.Collections;

public class StatueMovement : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform[] points;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float waitTime = 2f;

    private int currentPoint = 0;

    void Start()
    {
        if (points.Length == 0)
        {
            Debug.LogWarning(gameObject.name + " has no movement points assigned.");
            return;
        }

        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            // Move toward the current point
            while (Vector3.Distance(transform.position, points[currentPoint].position) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    points[currentPoint].position,
                    moveSpeed * Time.deltaTime
                );

                yield return null;
            }

            // Wait / cooldown at the point
            yield return new WaitForSeconds(waitTime);

            // Move to the next point
            currentPoint++;

            // Loop back to the first point
            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}