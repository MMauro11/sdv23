using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume2 : MonoBehaviour {

    public AudioMixer Mixer;
    public Slider VolumeSlider;

    public void SetLevel() {

        Mixer.SetFloat("MusicVol", Mathf.Log10(VolumeSlider.value) * 20);
        PlayerPrefs.SetFloat("VolumePrefs", VolumeSlider.value);
    }
}
