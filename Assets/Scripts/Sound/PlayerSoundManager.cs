using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour // made to play player's audio clips
{
    private AudioSource source;

    public AudioClip[] footsteps;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void AudioFootStep() // a random footstep audio clip (called in walk animation events)
    {
        source.clip = footsteps[Mathf.FloorToInt(UnityEngine.Random.value * footsteps.Length)];
        source.Play();
    }
}
