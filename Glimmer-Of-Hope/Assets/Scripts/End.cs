using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}