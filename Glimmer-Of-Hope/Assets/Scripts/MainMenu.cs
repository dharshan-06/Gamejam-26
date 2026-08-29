using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject homePage;
    public GameObject plotPanel;
    public GameObject settingsPanel;

    public Slider sfxSlider;

    void Start()
    {
        settingsPanel.SetActive(false);

        if (sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    public void StartGame()
    {
        homePage.SetActive(false);
        plotPanel.SetActive(true);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OpenSettings()
    {
        homePage.SetActive(true);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        homePage.SetActive(true);
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}