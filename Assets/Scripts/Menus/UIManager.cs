using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            anim.SetTrigger("KeyPressed");
        }
    }

    public void ShowLeaderboard()
    {
        anim.SetBool("Leaderboard", true);
    }

    public void HideLeaderboard()
    {
        anim.SetBool("Leaderboard", false);
    }

    public void ReadyUp() 
    {
        anim.SetTrigger("Ready");
    }
}
