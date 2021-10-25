using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour // made to play general audio clips
{
    private AudioSource source;
    private AudioSource bgSource;

    public AudioClip IntroSound;
    public AudioClip mouseClick;
    public AudioClip menuSelect;
    public AudioClip wallClosed;
    public AudioClip popBall;
    public AudioClip gameOver;
    public AudioClip gameOverSong;


    void Start()
    {
        source = GetComponent<AudioSource>();
        bgSource = GameObject.FindWithTag(Constants.BACKGROUND_AUDIO).GetComponent<AudioSource>();
    }

    public void IntroSoundClip() // plays audio from the title screen transition
    {
        source.volume = 0.2f;
        source.clip = IntroSound;
        source.Play();
    }

    public void AudioMouseClick() // plays audio when change outfit buttons are pressed
    {
        source.volume = 0.8f;
        source.clip = mouseClick;
        source.Play();
    }

    public void AudioMenuSelect() // plays audio when change menu buttons are pressed
    {
        source.volume = 1f;
        source.clip = menuSelect;
        source.Play();
    }

    public void AudioWallClosed() // plays audio when a wall is closed
    {
        source.volume = 1f;
        source.clip = wallClosed;
        source.Play();
    }

    public void AudioPopBall() // plays audio when a meteor is poped
    {
        source.volume = 0.1f;
        source.clip = popBall;
        source.Play();
    }

    public void AudioGameOverM() // plays audio on game over and starts new background music
    {
        source.volume = 1f;
        source.clip = gameOver;
        source.Play();

        bgSource.clip = gameOverSong;
        bgSource.Play();
    }


}
