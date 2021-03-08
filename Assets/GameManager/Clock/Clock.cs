using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to show remaining Round Time
/// An analog clock, with hands
/// NOTICE ONLY USING MINUTE HAND, HOUR HAND NOT IMPLEMENTED
/// <see href="https://docs.unity3d.com/ScriptReference/Transform.Rotate.html">Transform.Rotate</see>
/// </summary>
public class Clock : MonoBehaviour
{
    // We rotate this about the face
    public GameObject minuteHand;

    // We also rotate this about the face, albeit more slowly
    // TODO FUTURE
    public GameObject hourHand;

    // Who we notify on round over
    public GameManager gameManager;

    // What time remains right now
    public float currentTime;

    // What time we start with
    public float startTime = 90.0f;

    // When we are not runnin
    private bool stopped;

    void Start()
    {
        // Reset the time
        currentTime = startTime;

        // Set the alarm
        stopped = false;
    }

    void Update()
    {
        if (stopped)
        {
            return;
        }

        // If we should be running
        if (currentTime > 0.0f)
        {
            // Remove time while time remains
            currentTime -= Time.deltaTime;

            // Update the Minute Hand
            minuteHand.transform.Rotate(0.0f, 0.0f, 48 * Time.deltaTime, Space.Self);

            // Update the Hour Hand
            hourHand.transform.Rotate(0.0f, 0.0f, 4 * Time.deltaTime, Space.Self);
        }

        // Do something only once, when time stops
        if (currentTime < 0.0f)
        {
            TimeOut();
        }
    }

    /// <summary>
    /// Trigger effects, etc to signify time is up
    /// </summary>
    private void TimeOut()
    {
        // Alert the game manager the time is up
        gameManager.RoundOver();

        stopped = true;
    }

}
