using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Gameplay Animations Manager")]
    private GameplayAnimations gameAnims;

    private Rigidbody2D rb;
    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameAnims = GameObject.FindWithTag("AnimationManager").GetComponent<GameplayAnimations>();
        rb = GetComponent<Rigidbody2D>();
        fallSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, -fallSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameAnims.GameOver();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
