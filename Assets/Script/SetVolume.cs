using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {

    public AudioMixer Mixer;
    public Slider VolumeSlider;

    public void Start (){
            Mixer.SetFloat("MusicVol", Mathf.Log10(VolumeSlider.value) * 20);
    }
}
