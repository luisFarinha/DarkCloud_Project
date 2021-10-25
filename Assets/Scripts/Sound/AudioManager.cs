using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour // made to play general audio clips
{
    private AudioSource source;
    private AudioSource bgSource;

    public AudioClip mouseClick;
    public AudioClip menuSelect;
    public AudioClip gameOver;
    public AudioClip IntroSound;

    void Start()
    {
        source = GetComponent<AudioSource>();
        bgSource = GameObject.FindWithTag(Constants.BACKGROUND_AUDIO).GetComponent<AudioSource>();
    }

    public void AudioMouseClick() // plays audio when change outfit buttons are pressed
    {
        source.clip = mouseClick;
        source.Play();
    }

    public void AudioMenuSelect() // plays audio when change menu buttons are pressed
    {
        source.clip = menuSelect;
        source.Play();
    }

    public void AudioGameOverM() // plays audio on game over and stops background music
    {
        source.clip = gameOver;
        source.Play();
        bgSource.Stop();
    }

    public void IntroSoundClip() // plays audio from the title screen transition
    {
        source.clip = IntroSound;
        source.Play();
    }
}
