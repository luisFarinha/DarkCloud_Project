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

    private float sizeVariation = 0.5f;


    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameAnims = GameObject.FindWithTag("AnimationManager").GetComponent<GameplayAnimations>();
        scoreTxt = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        float randomSize = Random.Range(transform.localScale.x - sizeVariation, transform.localScale.x + sizeVariation);
        transform.localScale = new Vector2(randomSize, randomSize);

        Debug.Log(fallSpeed);

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
        else if (fallSpeed >= 16)
        {
            sr.color = new Color(1, 1, 1);
        }
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
            //gameAnims.GameOver();
        }
        else
        {
            scoreTxt.text = (System.Convert.ToInt32(scoreTxt.text) + 1).ToString();
            Destroy(this.gameObject);
        }
    }
}
