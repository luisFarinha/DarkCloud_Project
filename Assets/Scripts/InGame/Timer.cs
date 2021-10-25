using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour // made to count time at the start of the level
{
    private Text timeTxt;
    private float timer = 0;
    [Header("Wait Before Start")]
    public float WaitingTime = 6;

    void Start() 
    {
        timeTxt = GetComponent<Text>();
        timer -= WaitingTime; // decrement to start the timer only after the cutscene has ended
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 0)
        {
            // Time format to count as minutes and seconds (00:00)
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");

            timeTxt.text = string.Format("{0}:{1}", minutes, seconds);
        }
    }
}
