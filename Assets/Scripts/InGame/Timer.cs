using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timeTxt;
    private float timer = 0;
    [Header("Wait Before Start")]
    public float WaitingTime = 6;

    // Start is called before the first frame update
    void Start()
    {
        timeTxt = GetComponent<Text>();
        timer -= WaitingTime;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 0)
        {
            string minutes = Mathf.Floor(timer / 60).ToString("00"); //Rounds
            string seconds = (timer % 60).ToString("00");

            timeTxt.text = string.Format("{0}:{1}", minutes, seconds);
        }
    }
}
