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
    private AudioManager audioManager;

    private float randomSize;
    private float sizeVariation = 0.5f;
    private float colorVarCount = 0;
    private float sizeVarCount = 0;
    
    public float fallSpeed;
    public GameObject meteorSplash;

    void Start()
    {
        gameAnims = GameObject.FindWithTag(Constants.ANIMATION_MANAGER).GetComponent<GameplayAnimations>();
        scoreTxt = GameObject.FindWithTag(Constants.SCORE_TEXT).GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tm = GameObject.FindWithTag(Constants.LEADERBOARD_TABLE).GetComponent<TableManager>();
        audioManager = GameObject.FindWithTag(Constants.AUDIO_MANAGER).GetComponent<AudioManager>();

        // gives a random size to the meteor
        float randomSize = Random.Range(transform.localScale.x - sizeVariation, transform.localScale.x + sizeVariation);
        transform.localScale = new Vector2(randomSize, randomSize);

        // changes meteor color according to its fallspeed value
        if (fallSpeed >= 7 && fallSpeed < 9)
        {
            sr.color = new Color(0, 0, 1);
        }
        if (fallSpeed >= 9 && fallSpeed < 11)
        {
            sr.color = new Color(0.5f, 0, 1);
        }
        else if (fallSpeed >= 11 && fallSpeed < 13)
        {
            sr.color = new Color(1, 0, 0.5f);
        }
        else if (fallSpeed >= 13 && fallSpeed < 14)
        {
            sr.color = new Color(1, 0, 0);
        }
        else if (fallSpeed >= 14 && fallSpeed < 15)
        {
            sr.color = new Color(1, 1, 1);
        }
    }

    private void Update() // color and size changes in realTime
    {
        if (colorVarCount >= 1) { colorVarCount = 0; }
        if (sizeVarCount >= 1) { sizeVarCount = 0; }

        if (fallSpeed >= 15 && fallSpeed < 16)
        {
            sr.color = new Color(colorVarCount, 1 - colorVarCount, 1);
        }
        else if (fallSpeed >= 16 && fallSpeed < 17)
        {
            sr.color = new Color(colorVarCount, 1, 1 - colorVarCount);
        }
        else if (fallSpeed >= 17 && fallSpeed < 18)
        {
            sr.color = new Color(1, colorVarCount, 1 - colorVarCount);
        }
        else if(fallSpeed >= 18 && fallSpeed < 19)
        {
            sr.color = new Color(1 - colorVarCount, 1 - colorVarCount, 1 - colorVarCount);
            
            gameObject.transform.localScale = new Vector2(0.5f + (sizeVariation * sizeVarCount * 2),
                0.5f + (sizeVariation * sizeVarCount * 2));
        }
        else if (fallSpeed >= 19) // Spawning different multi colored meteors
        {
            float RandomBall = Random.Range(0, 3);
            if (RandomBall <= 1)
            {
                sr.color = new Color(colorVarCount, 1 - colorVarCount, 1);
            }
            else if(RandomBall > 1  && RandomBall <= 2)
            {
                sr.color = new Color(colorVarCount, 1, 1 - colorVarCount);
            }
            else if(RandomBall > 2)
            {
                sr.color = new Color(1, colorVarCount, 1 - colorVarCount);
            }

            gameObject.transform.localScale = new Vector2(0.5f + (sizeVariation * sizeVarCount * 2),
                0.5f + (sizeVariation * sizeVarCount * 2));
        }

        colorVarCount += 0.01f;
        sizeVarCount += 0.01f;
    }

    private void FixedUpdate() // Good and computing physics system calculations (runs every 0.02 seconds)
    {
        rb.velocity = new Vector2(0f, -fallSpeed); // applys downward velocity to meteors
    }

    [System.Obsolete]
    private void SpawnMeteorSplash() // spawns a particle system with the same atributes of the meteor
    {
        GameObject newMeteorSplash = Instantiate(meteorSplash) as GameObject;
        newMeteorSplash.transform.position = transform.position;
        newMeteorSplash.transform.localScale = transform.localScale / 2;
        newMeteorSplash.GetComponent<ParticleSystem>().startColor = sr.color;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If has collided with the player creates a leaderboard submission and plays game over animation
        if (col.gameObject.CompareTag(Constants.PLAYER)) 
        {
            tm.CreateRow();
            gameAnims.GameOver();
        }
        // Else increments score, plays pop audio and destroys itself
        else
        {
            SpawnMeteorSplash();
            scoreTxt.text = (int.Parse(scoreTxt.text) + 1).ToString();
            audioManager.AudioPopBall();
            Destroy(this.gameObject);
        }
    }
}
