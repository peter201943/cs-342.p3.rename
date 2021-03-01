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
    // Number of points gained on correct answer, MUST BE POSITIVE
    public int lovePointsGain;
    // Number of points lost on incorrect answer, MUST BE NEGATIVE
    public int lovePointsLoss;
    // Number of max points lost per round
    // TODO FUTURE
    // public int lovePointsMaxDecrementRound;

    [Header("Instance External References")]
    // Who we update with our score
    public Bar loveBar;
    // Who we notify of GameOver, etc
    public GameManager gameManager;

    [Header("Prefab External References")]
    // Where we spawn sessions
    public Transform sessionSpawnLocation;

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
    public Queue<GameObject> sessionQueue;
    // The active dialog session
    public GameObject currentSession;

    [Header("Misc Debug")]
    // Whether the player has lost the game
    public bool stopped;
    // Randomization
    // TODO FUTURE
    // public int random = 5;
    // public int maxRandom = 12;

    /// <summary>
    /// Setup the Love Minigame
    /// </summary>
    void Start()
    {
        // Setup the Sessions Queue
        NewQueue();

        // Pick our first Session
        SpawnSession();

        // Reset the Score
        lovePointsCurrent = lovePointsStart;
        UpdateScore(0);
        stopped = false;
    }

    /// <summary>
    /// Creates a new queue of sessions from the current set
    /// Orders them randomly
    /// </summary>
    private void NewQueue()
    {
        // Clear Current Queue
        sessionQueue.Clear();
        // Shuffle the List
        // TODO
        // Add all of the items of the list
        foreach (GameObject nextSession in sessions)
        {
            sessionQueue.Enqueue(nextSession);
        }
    }

    /// <summary>
    /// Player answers a question correctly
    /// </summary>
    public void Correct()
    {
        UpdateScore(lovePointsGain);
    }

    /// <summary>
    /// Player answers a question incorrectly
    /// </summary>
    public void InCorrect()
    {
        UpdateScore(lovePointsLoss);
    }


    /// <summary>
    /// Does all manner of
    /// * side-effects
    /// * notifications
    /// * computations
    /// All part of a nice, simple interface though
    /// </summary>
    /// <param name="change">The amount we change the score by</param>
    private void UpdateScore(int change)
    {
        // Update Internal Value
        lovePointsCurrent += change;

        // Update UI
        loveBar.UpdateScore(lovePointsCurrent);

        // Check for Loss
        if (change < 0)
        {
            // Trigger any Side Effects
            // TODO
        }

        // Check for Gain
        if (change > 0)
        {
            // Trigger any Side Effects
            // TODO
        }

        // Check for GameOver
        if (lovePointsCurrent <= 0 && !stopped)
        {
            gameManager.OnGameOver();
            stopped = true;
        }
    }

    /// <summary>
    /// Session Spawning, etc
    /// </summary>
    private void Update()
    {
        // Update Session Logic
        SessionUpdate();

        // Update Difficulty Logic
        DifficultyUpdate();
    }

    /// <summary>
    /// TODO Add Details
    /// </summary>
    private void SessionUpdate()
    {
        // When a session is over, start timer for next one

        // when session and timer over, check if session queue has any sessions and get the next one

        // if session queue empty, remake it and pick next session

        // tell session to start with our time values
    }

    /// <summary>
    /// Each frame, adjust the difficulty timers
    /// </summary>
    private void DifficultyUpdate()
    {
        // Spawn Difficulty

        // Message Difficulty
    }

    /// <summary>
    /// Handles everything regarding spawning a new session
    /// </summary>
    private void SpawnSession()
    {
        // Delete the Current Session
        Destroy(currentSession);

        // Pick Next Session
        currentSession = Instantiate(sessionQueue.Dequeue(), sessionSpawnLocation.position, Quaternion.identity);

        // Spawn it
    }

}
