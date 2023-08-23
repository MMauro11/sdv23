using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    /*
    public AudioMixer Mixer;
    public Slider VolumeSlider;
    */
    void Start() {
        /*
        if (PlayerPrefs.HasKey("VolumePrefs")) {

            float volumePrefs = PlayerPrefs.GetFloat("VolumePrefs");
            Mixer.SetFloat("MusicVol", Mathf.Log10(volumePrefs) * 20);
            VolumeSlider.value = volumePrefs;
        } else 
        {
            float initialVolume = VolumeSlider.value;
            Mixer.SetFloat("MusicVol", Mathf.Log10(initialVolume) * 20);
        }
        */

    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGalaxyMap(){
        SceneManager.LoadScene("GalaxyMap");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
