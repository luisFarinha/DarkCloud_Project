using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource source;

    public AudioClip[] footsteps;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioFootStep()
    {
        source.clip = footsteps[Mathf.FloorToInt(UnityEngine.Random.value * footsteps.Length)];
        source.Play();
    }
}
