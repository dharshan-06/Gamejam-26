using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelIntro : MonoBehaviour
{
    public Image levelImage;
    public float displayTime = 2f;
    public float fadeTime = 1f;

    public LevelTutorial tutorial;

    void Start()
    {
        StartCoroutine(ShowLevelIntro());
    }

    IEnumerator ShowLevelIntro()
    {
        Color color = levelImage.color;
        color.a = 1f;
        levelImage.color = color;

        yield return new WaitForSeconds(displayTime);

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;

            color.a = Mathf.Lerp(1f, 0f, timer / fadeTime);
            levelImage.color = color;

            yield return null;
        }

        color.a = 0f;
        levelImage.color = color;

        // Level intro is completely finished
        if (tutorial != null)
        {
            tutorial.StartTutorial();
        }
    }
}