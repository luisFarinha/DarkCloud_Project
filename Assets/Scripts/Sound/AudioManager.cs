using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    private AudioSource bgSource;

    public AudioClip mouseClick;
    public AudioClip menuSelect;
    public AudioClip gameOver;
    public AudioClip IntroSound;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        bgSource = GameObject.FindWithTag("bgAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioMouseClick()
    {
        source.clip = mouseClick;
        source.Play();
    }

    public void AudioMenuSelect()
    {
        source.clip = menuSelect;
        source.Play();
    }

    public void AudioGameOverM()
    {
        source.clip = gameOver;
        source.Play();
        bgSource.Stop();
    }

    public void IntroSoundClip()
    {
        source.clip = IntroSound;
        source.Play();
    }
}
