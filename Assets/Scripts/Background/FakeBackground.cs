using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBackground : MonoBehaviour
{
    private AudioManager audioManager;
    private AudioSource source;
    
    public AudioClip earthquake;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        audioManager = GameObject.FindWithTag(Constants.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    public void PlayThumpSound() // plays when a thump sound in the bgfall animation events
    {
        audioManager.IntroSoundClip();
    }

    public void AudioEarthquake() // plays audio when a earthquake starts
    {
        source.volume = 1f;
        source.clip = earthquake;
        source.Play();
    }


}
