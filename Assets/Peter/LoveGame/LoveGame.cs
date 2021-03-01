using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Love Minigame
/// * This is 1 of 2 minigames
/// * It involves mouse interaction/clicking on dialog bubbles
/// * It draws from a set of prewritten questions
/// * And displays them based off of timers
/// 
/// TODO FUTURE
/// * Add a timer/slider at bottom of screen showing how much time to answer a question remains
/// * Adjust the max love points to be smaller and smaller over time - also add effects to indicate such!
/// </summary>
public class LoveGame : MonoBehaviour
{
    [Header("The points a player has")]
    // What the player acrrues playing the game
    public int lovePointsCurrent;
    // What value the player starts the game with
    public int lovePointsStart;
    // The most points a player can get (part of difficulty?)
    public int lovePointsMax;

    [Header("Love Points Difficulty")]
    // Number of points gained on correct answer
    public int lovePointsGain;
    // Number of points lost on incorrect answer
    public int lovePointsLoss;
    // Number of max points lost per round
    // TODO FUTURE
    // public int lovePointsMaxDecrementRound;

    [Header("External References")]
    // Who we update with our score
    public Bar loveBar;
    // Who we notify of GameOver, etc
    public GameManager gameManager;

    [Header("Question Spawning Difficulty")]
    // The max time a question can take to spawn
    public float sessionSpawnDelayMax;
    // The min time a question can take to spawn
    public float sessionSpawnDelayMin;
    // How quickly questions take less time spawn
    public float sessionSpawnDelayDecrementRate;

    [Header("Session Timing Difficulty")]
    // The max time a question can be show
    public float sessionAnswerDelayMax;
    // The min time a question can be shown
    public float sessionAnswerMin;
    // How quickly questions take less time to be shown
    public float sessionAnswerDecrementRate;

    [Header("Selection Choosing")]
    // All possible sessions, NOT MUTATED
    public List<GameObject> sessions;
    // The current order of sessions, MUTATED, DO NOT MODIFY
    public List<GameObject> sessionQueue;
    // The active dialog session
    public GameObject currentSession;

    /// <summary>
    /// Setup the Love Minigame
    /// </summary>
    void Start()
    {
        // Setup the Sessions Queue
        // TODO

        // Pick our first Session
        // TODO

        // Reset the Score
        lovePointsCurrent = lovePointsStart;
    }

    /// <summary>
    /// Creates a new queue of sessions from the current set
    /// Orders them randomly
    /// </summary>
    private void NewQueue()
    {

    }

    /// <summary>
    /// Player answers a question correctly
    /// </summary>
    public void Correct()
    {
        // TODO
    }

    /// <summary>
    /// Player answers a question incorrectly
    /// </summary>
    public void InCorrect()
    {
        // TODO
    }


}
