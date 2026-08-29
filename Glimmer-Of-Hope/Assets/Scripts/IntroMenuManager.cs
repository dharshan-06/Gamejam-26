using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuManager : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }
}