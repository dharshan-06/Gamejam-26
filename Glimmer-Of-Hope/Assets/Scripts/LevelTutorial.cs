using UnityEngine;

public class LevelTutorial : MonoBehaviour
{
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint4;

    public PlayerMovement playerMovement;

    private int currentHint = 0;
    private bool tutorialStarted = false;

    void Start()
    {
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint4.SetActive(false);

        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (!tutorialStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            ShowNextHint();
        }
    }

    public void StartTutorial()
    {
        tutorialStarted = true;

        hint1.SetActive(true);
    }

    void ShowNextHint()
    {
        if (currentHint == 0)
        {
            hint1.SetActive(false);
            hint2.SetActive(true);
            currentHint = 1;
        }
        else if (currentHint == 1)
        {
            hint2.SetActive(false);
            hint3.SetActive(true);
            currentHint = 2;
        }
        else if (currentHint == 2)
        {
            hint3.SetActive(false);
            hint4.SetActive(true);
            currentHint = 3;
        }
        else if (currentHint == 3)
        {
            hint4.SetActive(false);

            playerMovement.enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            tutorialStarted = false;
            currentHint = 4;
        }
    }
}