using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(DropWall());
    }

    private IEnumerator DropWall()
    {
        yield return new WaitForSeconds(CutsceneVars.SecondCutsceneTimer);

        anim.Play("ClosePassage");
    }
}
