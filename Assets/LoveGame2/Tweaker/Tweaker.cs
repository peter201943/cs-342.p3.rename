using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <see href="https://gamedev.stackexchange.com/questions/110914/check-elapsed-time-in-unity/110915">Check elapsed time in Unity?</see>
/// Globally Changes values by time
/// </summary>
public class Tweaker : LoveGameBehavior
{
    private float currentDelay;

    private void Update()
    {
        subject.delay -= rate / 100f * (Time.time / 100f) / delay;
    }
}
