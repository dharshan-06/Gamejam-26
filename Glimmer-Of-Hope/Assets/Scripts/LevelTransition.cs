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

    void Start()
    {
        Color color = blackScreen.color;
        color.a = 1f;
        blackScreen.color = color;

        StartCoroutine(FadeOut());
    }

    public void GoToNextLevel()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return StartCoroutine(Fade(0f, 1f, fadeInTime));

        if (doorSound != null)
            doorSound.Play();

        yield return new WaitForSeconds(blackTime);

        int currentScene = SceneManager.GetActiveScene().buildIndex;

       if (currentScene == 4)
{
    SceneManager.LoadScene(5);
}
else
{
    SceneManager.LoadScene(currentScene + 1);
}
    }

    IEnumerator FadeOut()
    {
        yield return StartCoroutine(Fade(1f, 0f, fadeOutTime));
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        Color color = blackScreen.color;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            color.a = Mathf.Lerp(
                startAlpha,
                endAlpha,
                timer / duration
            );

            blackScreen.color = color;

            yield return null;
        }

        color.a = endAlpha;
        blackScreen.color = color;
    }
}