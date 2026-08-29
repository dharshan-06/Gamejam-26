using UnityEngine;
using UnityEngine.UI;

public class PauseSettings : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider sfxSlider;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetSFXVolume()
    {
        AudioListener.volume = sfxSlider.value;
    }

    void Start()
    {
        settingsPanel.SetActive(false);
        sfxSlider.value = AudioListener.volume;
    }
}