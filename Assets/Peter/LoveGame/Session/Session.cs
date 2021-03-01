using System.Collections;
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
    // Which answers are ok
    public List<Answer> goodAnswers;
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
        foreach (Answer goodAnswer in goodAnswers)
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
