using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    private Animator anim;
    private AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindWithTag(Constants.AUDIO_MANAGER).GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) // if a key is pressed triggers the key pressed parameter (used to change from the title to the main menu)
        {
            anim.SetTrigger(Constants.KEY_PRESSED);
        }
    }

    public void ShowLeaderboard() // sets leaderboard parameter true to play show leaderboard animation
    {
        anim.SetBool(Constants.LEADERBOARD, true);
    }

    public void HideLeaderboard() // sets leaderboard parameter false to play hide leaderboard animation
    {
        anim.SetBool(Constants.LEADERBOARD, false);
    }

    public void ReadyUp() // sets ready parameter true to play fading animation with a scene changing event to the level scene
    {
        anim.SetBool(Constants.READY,true);
    }

    public void IntroClickSound() // plays a audio clip during the title screen transition
    {
        audioManager.IntroSoundClip();
    }
}
