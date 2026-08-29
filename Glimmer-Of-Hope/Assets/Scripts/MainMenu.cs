using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject storyPanel;
    public GameObject settingsPanel;
    public PlayerMovement playerMovement;

    public void StartGame()
    {
        storyPanel.SetActive(true);
        playerMovement.canMove = false;
    }

    public void ContinueGame()
    {
        playerMovement.canMove = true;
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        playerMovement.canMove = false;
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}