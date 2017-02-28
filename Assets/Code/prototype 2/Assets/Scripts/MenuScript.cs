using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public AudioMixer MasterMixer;
    public Slider musicSlider;
    public Slider EffectsSlider;
    

    private void Start()
    {
        MusicSound(PlayerPrefs.GetFloat("MusicVolume"));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        EffectsSound(PlayerPrefs.GetFloat("EffectsVolume"));
        EffectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
    }

    public void OpenPanel(GameObject panelToOpen)
    {
        panelToOpen.SetActive(true);
    }

    public void ClosePanel(GameObject panelToClose)
    {
        panelToClose.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicSound(float Lvl)
    {
        MasterMixer.SetFloat("Music", Lvl);
        PlayerPrefs.SetFloat("MusicVolume", Lvl);
    }

    public void EffectsSound(float Lvl)
    {
        MasterMixer.SetFloat("Effects", Lvl);
        PlayerPrefs.SetFloat("EffectsVolume", Lvl);
    }
}
