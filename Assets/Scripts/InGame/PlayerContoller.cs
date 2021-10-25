using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed;
    private float moveDir;

    private bool canControlPlayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        StartCoroutine(WalkToCenter());
    }

    void Update()
    {
        // gets results of -1, 0 and 1 based on A/D or Left/Right Arrows being pressed
        if (canControlPlayer) { moveDir = Input.GetAxisRaw("Horizontal"); } 
    }

    private void FixedUpdate()
    {
        // if has player movement control then moves player to the respective direction
        if (canControlPlayer) { rb.velocity = new Vector2(moveDir * moveSpeed, 0f); } 

        // changes the looking direction of the player
        if(moveDir < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.Play(Constants.PLAYER_WALK);
        }
        else if(moveDir > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.Play(Constants.PLAYER_WALK);
        }
        else
        {
            anim.Play(Constants.PLAYER_IDLE);
        }
    }

    private IEnumerator WalkToCenter() // moves player to the center of the field until its 'animation' timer is over
    {
        moveDir = 1f;
        rb.velocity = new Vector2(moveDir * moveSpeed, 0f);

        yield return new WaitForSeconds(CutsceneVars.FirstCutsceneTimer);

        canControlPlayer = true; // gives player movement control back to the user
    }
}
