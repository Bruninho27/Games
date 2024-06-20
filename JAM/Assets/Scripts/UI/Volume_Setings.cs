using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume_Setings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float Volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(Volume)*20);
    }
    public void SetSFXVolume()
    {
        float Volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(Volume) * 20);
    }

}
