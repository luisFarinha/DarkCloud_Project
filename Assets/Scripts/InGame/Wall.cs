using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour // simple wall script
{
    private Animator anim;
    private AudioManager audioManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindWithTag(Constants.AUDIO_MANAGER).GetComponent<AudioManager>();

        StartCoroutine(DropWall());
    }

    private IEnumerator DropWall() // play close passage animation after the second cutscene animation has played
    {
        yield return new WaitForSeconds(CutsceneVars.SecondCutsceneTimer);

        anim.Play("ClosePassage");
    }

    public void playCloseWallAudio() // called as an event at the end of Close Passage animation
    {
        audioManager.AudioWallClosed();
    }
}
