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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        StartCoroutine(WalkToCenter());
    }

    // Update is called once per frame
    void Update()
    {
        if (canControlPlayer) { moveDir = Input.GetAxisRaw("Horizontal"); }
    }

    private void FixedUpdate()
    {
        if (canControlPlayer) { rb.velocity = new Vector2(moveDir * moveSpeed, 0f); }

        if(moveDir < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.Play("walk");
        }
        else if(moveDir > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.Play("walk");
        }
        else
        {
            anim.Play("idle");
        }
    }

    private IEnumerator WalkToCenter()
    {
        moveDir = 1f;
        rb.velocity = new Vector2(moveDir * moveSpeed, 0f);

        yield return new WaitForSeconds(CutsceneVars.FirstCutsceneTimer);

        canControlPlayer = true;
    }
}
