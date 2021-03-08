using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loss : MonoBehaviour
{
    public  Slider  bar;
    public  float   delay           = 5f;
    private float   currentDelay    = 5f;
    public  int     rate            = 2;
    public  float   delayRate       = 1.5f;

    void Update()
    {
        currentDelay -= Time.deltaTime;
        if ( currentDelay < 0.0f )
        {
            currentDelay = delay;
            delay = delay / delayRate;
            bar.value = bar.value - rate;
        }
    }
}
