using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loss : MonoBehaviour
{
    // What we take from
    public  Slider  bar;
    // how frequently we take
    public  float   delay           = 2f;
    private float   currentDelay    = 2f;
    // how much we take each time
    public  float   rate            = 0.3f;
    // time we lose on the delay
    public  float   delayRate       = 1.1f;

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
