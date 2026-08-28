using UnityEngine;
using System.Collections;

public class RandomDoorActivator : MonoBehaviour
{
    [Header("Doors")]
    public GameObject[] doors;

    [Header("Timing")]
    public float activeDuration = 5f;
    public float delayBetweenDoors = 2f;

    private void Start()
    {
        StartCoroutine(RandomDoorRoutine());
    }

    IEnumerator RandomDoorRoutine()
    {
        while (true)
        {
            // Disable all doors first
            foreach (GameObject door in doors)
            {
                if (door != null)
                    door.SetActive(false);
            }

            // Select one random door
            if (doors.Length > 0)
            {
                int randomIndex = Random.Range(0, doors.Length);
                GameObject selectedDoor = doors[randomIndex];

                if (selectedDoor != null)
                {
                    // Enable selected door
                    selectedDoor.SetActive(true);

                    // Keep it active
                    yield return new WaitForSeconds(activeDuration);

                    // Disable it
                    selectedDoor.SetActive(false);
                }
            }

            // Wait before selecting next door
            yield return new WaitForSeconds(delayBetweenDoors);
        }
    }
}