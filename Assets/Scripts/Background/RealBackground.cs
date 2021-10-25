using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBackground : MonoBehaviour
{
    private float rotationSpeed = 0.01f;

    private float initialScaleX;
    private float scaleSpeed = 0.004f;
    private bool ascend = true;

    private void Start()
    {
        initialScaleX = transform.localScale.x;
    }

    void Update() // responsible for background animations
    {
        if(Time.timeScale != 0) // cant play during pause menu
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - rotationSpeed);
            rotationSpeed += 0.0001f;

            if (Time.time >= 60) // Time when the beat drops
            {
                if (transform.localScale.x >= initialScaleX * 1.5f) { ascend = false; }
                if (transform.localScale.x <= initialScaleX * 0.9f) { ascend = true; }

                if (ascend)
                {
                    transform.localScale = new Vector3(transform.localScale.x + scaleSpeed, transform.localScale.y + scaleSpeed, 0);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x - scaleSpeed, transform.localScale.y - scaleSpeed, 0);
                }
            }
        }

    }
}
