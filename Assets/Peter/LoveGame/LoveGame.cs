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
    // The next time a question can take to spawn
    public float sessionSpawnDelayNext;
    // The max time a question can take to spawn
    public float sessionSpawnDelayMax;
    // The min time a question can take to spawn
    public float sessionSpawnDelayMin;
    // How quickly questions take less time spawn
    public float sessionSpawnDelayDecrementRate;

    [Header("Session Timing Difficulty")]
    // The next time a question can be shown, DO NOT MODIFY
    public float sessionAnswerDelayNext;
    // The max time a question can be shown
    public float sessionAnswerDelayMax;
    // The min time a question can be shown
    public float sessionAnswerDelayMin;
    // How quickly questions take less time to be shown
    public float sessionAnswerDelayDecrementRate;

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
    // We are done finding new difficulties for spawn
    public bool sessionSpawnDelayDifficultyDone;
    // We are done finding new difficulties for messages
    public bool sessionAnswerDelayDifficultyDone;
    // The current spawn delay
    public float sessionSpawnDelayCurrent;
    // Whether we already have a session in play
    public bool sessionRunning;


    /// <summary>
    /// Setup the Love Minigame
    /// </summary>
    void Start()
    {
        // Reset the Score
        lovePointsCurrent = lovePointsStart;
        UpdateScore(0);

        // Reset State
        stopped = false;
        sessionSpawnDelayDifficultyDone = false;
        sessionAnswerDelayDifficultyDone = false;

        // Fill the Queue for the first time
        foreach (GameObject nextSession in sessions)
        {
            sessionQueue.Enqueue(nextSession);
        }

        // DEBUG I AM GOING CRAZY
        Debug.Log(sessionQueue);

        // Pick our first Session
        SpawnSession();
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
        // Play any side effects
        // TODO FUTURE

        // Update the Score
        UpdateScore(lovePointsGain);

        // Reset Session
        sessionRunning = false;
    }

    /// <summary>
    /// Player answers a question incorrectly
    /// </summary>
    public void InCorrect()
    {
        // Play any side effects
        // TODO FUTURE

        // Update the Score
        UpdateScore(lovePointsLoss);

        // Reset Session
        sessionRunning = false;
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
            // TODO FUTURE
        }

        // Check for Gain
        if (change > 0)
        {
            // Trigger any Side Effects
            // TODO FUTURE
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
    /// Each frame, run logic for sessions
    /// </summary>
    private void SessionUpdate()
    {
        // When a session is over
        if ( !sessionRunning )
        {
            // Decrement Timer
            sessionSpawnDelayCurrent -= Time.deltaTime;
        }

        // when enough time has elapsed
        if ( sessionSpawnDelayCurrent <= 0.0f )
        {
            // Reset Timer
            sessionSpawnDelayCurrent = sessionSpawnDelayNext;

            // Make New Session
            SpawnSession();
        }
    }

    /// <summary>
    /// Each frame, adjust the difficulty timers
    /// </summary>
    private void DifficultyUpdate()
    {
        // Spawn Difficulty increases over time
        if (!sessionSpawnDelayDifficultyDone)
        {
            // Find new time
            float nextTime = sessionSpawnDelayNext - sessionSpawnDelayDecrementRate * Time.deltaTime;

            // See if it is at our minimum
            if (nextTime > sessionSpawnDelayMin)
            {
                sessionSpawnDelayNext = nextTime;
            }

            // stop if it is
            if (nextTime <= sessionSpawnDelayMin)
            {
                sessionSpawnDelayNext = sessionSpawnDelayMin;
                sessionSpawnDelayDifficultyDone = true;
            }
        }

        // Message difficulty increases over time
        if (!sessionAnswerDelayDifficultyDone)
        {
            // Find new time
            float nextTime = sessionAnswerDelayNext - sessionAnswerDelayDecrementRate * Time.deltaTime;

            // See if it is at our minimum
            if (nextTime > sessionAnswerDelayMax)
            {
                sessionAnswerDelayNext = nextTime;
            }

            // stop if it is
            if (nextTime <= sessionAnswerDelayMin)
            {
                sessionAnswerDelayNext = sessionAnswerDelayMin;
                sessionAnswerDelayDifficultyDone = true;
            }
        }
    }

    /// <summary>
    /// Handles everything regarding spawning a new session
    /// </summary>
    private void SpawnSession()
    {
        // Delete the Current Session
        Destroy(currentSession);

        // Check if queue empty and refill it if it is
        if (sessionQueue.Count <= 0)
        {
            NewQueue();
        }

        // Pick Next Session and Instantiate it
        currentSession = Instantiate(
            sessionQueue.Dequeue(),
            sessionSpawnLocation.position,
            Quaternion.identity);

        // Make it our child (keep scene tree clean)
        currentSession.transform.parent = this.gameObject.transform;

        // Get reference to session
        Session session = currentSession.GetComponent<Session>();

        // Configure the Session
        session.loveGame = this;
        session.currentTime = sessionAnswerDelayNext;

        // Reset Trackers
        sessionRunning = true;
    }

}
