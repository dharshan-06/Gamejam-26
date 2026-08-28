using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    public Image blackScreen;
    public AudioSource doorSound;

    public float fadeInTime = 0.3f;
    public float blackTime = 1f;
    public float fadeOutTime = 1f;

    public void GoToNextLevel()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        Color color = blackScreen.color;

        float timer = 0f;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            blackScreen.color = color;
            yield return null;
        }

        color.a = 1f;
        blackScreen.color = color;

        if (doorSound != null)
            doorSound.Play();

        yield return new WaitForSeconds(blackTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}