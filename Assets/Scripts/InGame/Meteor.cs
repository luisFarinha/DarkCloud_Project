using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{
    private GameplayAnimations gameAnims;
    private Text scoreTxt;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private TableManager tm;

    private float sizeVariation = 0.5f;

    public float fallSpeed;

    void Start()
    {
        gameAnims = GameObject.FindWithTag(Constants.ANIMATION_MANAGER).GetComponent<GameplayAnimations>();
        scoreTxt = GameObject.FindWithTag(Constants.SCORE_TEXT).GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tm = GameObject.FindWithTag(Constants.LEADERBOARD_TABLE).GetComponent<TableManager>();

        // gives a random size to the meteor
        float randomSize = Random.Range(transform.localScale.x - sizeVariation, transform.localScale.x + sizeVariation);
        transform.localScale = new Vector2(randomSize, randomSize);

        // changes meteor color according to its fallspeed value
        if (fallSpeed >= 7 && fallSpeed < 9)
        {
            sr.color = new Color(0, 0, 1);
        }
        else if (fallSpeed >= 9 && fallSpeed < 11)
        {
            sr.color = new Color(0.5f, 0, 1);
        }
        else if (fallSpeed >= 11 && fallSpeed < 13)
        {
            sr.color = new Color(0.7f, 0, 0.7f);
        }
        else if (fallSpeed >= 13 && fallSpeed < 14)
        {
            sr.color = new Color(1, 0, 0.5f);
        }
        else if (fallSpeed >= 14 && fallSpeed < 15)
        {
            sr.color = new Color(1, 0, 0);
        }
        else if (fallSpeed >= 15 && fallSpeed < 16)
        {
            sr.color = new Color(0, 0, 0);
        }
        else if (fallSpeed >= 16 && fallSpeed < 17)
        {
            sr.color = new Color(0.3f, 0.3f, 0.3f);
        }
        else if (fallSpeed >= 17 && fallSpeed < 18)
        {
            sr.color = new Color(0.6f, 0.6f, 0.6f);
        }
        else if (fallSpeed >= 18 && fallSpeed < 19)
        {
            sr.color = new Color(1, 1, 1);
        }
    }

    private void FixedUpdate() // Good and computing physics system calculations (runs every 0.02 seconds)
    {
        rb.velocity = new Vector2(0f, -fallSpeed); // applys downward velocity to meteors
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If has collided with the player creates a leaderboard submission and plays game over animation
        if (col.gameObject.CompareTag(Constants.PLAYER)) 
        {
            tm.CreateRow();
            gameAnims.GameOver();
        }
        // Else increments score and destroys itself
        else
        {
            scoreTxt.text = (int.Parse(scoreTxt.text) + 1).ToString();
            Destroy(this.gameObject);
        }
    }
}
