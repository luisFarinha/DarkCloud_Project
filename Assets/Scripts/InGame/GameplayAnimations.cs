using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAnimations : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(CameraShake());
        StartCoroutine(DontGetHit());
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
}
