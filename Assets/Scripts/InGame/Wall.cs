using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour // simple wall script
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(DropWall());
    }

    private IEnumerator DropWall() // play close passage animation after the second cutscene animation has played
    {
        yield return new WaitForSeconds(CutsceneVars.SecondCutsceneTimer);

        anim.Play("ClosePassage");
    }
}
