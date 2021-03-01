﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to represent dialog between player and lover
/// Has a Message UI component
/// Good Answers
/// and Bad Answers
/// </summary>
public class Session : MonoBehaviour
{
    // Who we notify
    public LoveGame loveGame;
    // all of the answers
    // Which answers are ok NOTICE MUST BE CONFIGURED
    public List<GameObject> goodAnswers;
    // Time remaining to answer the question
    public float currentTime;
    // Are we done?
    public bool done;

    /// <summary>
    /// Setup fo simple state management
    /// </summary>
    private void Start()
    {
        // Reset state
        done = false;

        // Ensure each child Answer has a reference to us
        foreach (Transform child in this.transform)
        {
            try
            {
                Answer nextAnswer = child.gameObject.GetComponent<Answer>();
                nextAnswer.session = this;
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// When player fails to answer on time
    /// </summary>
    private void TimeOut()
    {
        loveGame.InCorrect();
        // TODO FUTURE
        // Any side effects for being slow
        return;
    }

    /// <summary>
    /// Update the Timer
    /// </summary>
    private void Update()
    {
        if (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0.0f)
        {
            TimeOut();
        }
    }

    /// <summary>
    /// When one of the answers reports being clicked
    /// </summary>
    /// <param name="sender"></param>
    public void Answer(GameObject sender)
    {
        // Check if it is a correct answer
        foreach (GameObject goodAnswer in goodAnswers)
        {
            if (sender == goodAnswer)
            {
                loveGame.Correct();
                // TODO FUTURE
                // Any Side Effects for being correct
                return;
            }
        }
        loveGame.InCorrect();
        // TODO FUTURE
        // Any side effects for being wrong
        return;
    }
}
