using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip background;
    public AudioClip derrota;
    public AudioClip errar;
    public AudioClip passouItem;
    public AudioClip novogame;
    public AudioClip esteira;
    public AudioClip novoobjesteira;
    public AudioClip vitoria;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
