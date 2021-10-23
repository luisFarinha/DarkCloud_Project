using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAnimations : MonoBehaviour
{
    private Animator anim;

    private bool lockScrollMenus;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(CameraShake());
        StartCoroutine(DontGetHit());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !lockScrollMenus)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("ScrollInPlay"))
            {
                anim.Play("ScrollOutPlay");
            }
            else
            {
                anim.Play("ScrollInPlay");
            }
        }
    }

    private IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(CutsceneVars.FirstCutsceneTimer);

        anim.Play("CameraShake");
    }

    private IEnumerator DontGetHit()
    {
        yield return new WaitForSeconds(CutsceneVars.ThirdCutsceneTimer);

        anim.Play("DGHPopUp");
    }

    public void GameOver()
    {
        lockScrollMenus = true;
        Time.timeScale = 0;
        anim.Play("GameOver");
    }

    public void TryAgain()
    {
        anim.Play("PlayToPlay");    
    }

    public void ExitToMenus()
    {
        anim.Play("PlayToEdit");
    }

    public void MenuScrollOut()
    {
        anim.Play("ScrollOutPlay");
    }

    public void ShowLeaderboard()
    {
        anim.Play("LeaderboardScrollIn");
    }

    public void HideLeaderboard()
    {
        anim.Play("LeaderboardScrollOut");
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
