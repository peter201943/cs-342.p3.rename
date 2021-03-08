using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantTweaker : LoveGameBehavior
{
    private float currentDelay;

    private void Update()
    {
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0.0f)
        {
            currentDelay = delay;
            subject.delay -= rate;
        }
    }
}
