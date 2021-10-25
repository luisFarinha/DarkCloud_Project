using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAnimations : MonoBehaviour // manages all UI and cutscene Animations during play
{
    private Animator anim;
    private AudioSource bgAudio;
    private AudioManager audioManager;

    private bool lockScrollMenus; // locks player costumization menu in case of a game over

    void Start()
    {
        anim = GetComponent<Animator>();
        bgAudio = GameObject.FindWithTag(Constants.BACKGROUND_AUDIO).GetComponent<AudioSource>();
        audioManager = GameObject.FindWithTag(Constants.AUDIO_MANAGER).GetComponent<AudioManager>();
        
        //coroutines for cutscene animations
        StartCoroutine(CameraShake());
        StartCoroutine(DontGetHit());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !lockScrollMenus) // by clicking Escape the user can enter or exit the player costumization menu
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(Constants.SCROLL_IN_PLAY))
            {
                anim.Play(Constants.SCROLL_OUT_PLAY);
            }
            else
            {
                anim.Play(Constants.SCROLL_IN_PLAY);
            }
        }
    }

    private IEnumerator CameraShake() // calls a camera shake animation after the 1st cutscene animation is played
    {
        yield return new WaitForSeconds(CutsceneVars.FirstCutsceneTimer);

        anim.Play(Constants.CAMERA_SHAKE);
    }

    private IEnumerator DontGetHit() // calls a dont get hit animation after the 3rd cutscene animation is played
    {
        yield return new WaitForSeconds(CutsceneVars.ThirdCutsceneTimer);

        anim.Play(Constants.DONT_GET_HIT);
    }

    public void GameOver() // is called when the player gets hit by a meteor (also stops time and locks the costumization menu)
    {
        anim.SetBool(Constants.GAME_OVER, true);
        lockScrollMenus = true;
        StopTime();
        audioManager.AudioGameOverM();
        anim.Play(Constants.GAME_OVER);
    }

    public void TryAgain() // plays try again animation with an event that restarts the scene
    {
        anim.Play(Constants.PLAY_TO_PLAY);    
    }

    public void ExitToMenus() // plays fade in animation with an event that changes to the main menu scene
    {
        anim.Play(Constants.PLAY_TO_EDIT);
    }

    public void MenuScrollOut() // plays scroll out menu animation
    {
        anim.Play(Constants.SCROLL_OUT_PLAY);
    }

    public void ShowLeaderboard() // plays show leaderboard animation
    {
        anim.Play(Constants.LEADERBOARD_SCROLL_IN);
    }

    public void HideLeaderboard() // plays hide leaderboard animation
    {
        anim.Play(Constants.LEADERBOARD_SCROLL_OUT);
    }

    public void StopTime() // stops in game time and pauses background music
    {
        Time.timeScale = 0;
        bgAudio.Pause();
    }

    public void ResumeTime() // resumes in game time and unpauses background music
    {
        Time.timeScale = 1;
        bgAudio.UnPause();
    }
}
