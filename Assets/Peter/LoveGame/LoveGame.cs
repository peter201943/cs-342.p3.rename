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

    [Header("External References")]
    // Who we update with our score
    public Bar loveBar;
    // Who we notify of GameOver, etc
    public GameManager gameManager;

    [Header("Question Spawning Difficulty")]
    // The max time a question can take to spawn
    public float questionSpawnDelayMax;
    // The min time a question can take to spawn
    public float questionSpawnDelayMin;
    // How quickly questions take less time spawn
    public float questionSpawnDelayDecrementRate;

    [Header("Answer Difficulty")]
    // The max time a question can be show
    public float answerDelayMax;
    // The min time a question can be shown
    public float answerDelayMin;
    // How quickly questions take less time to be shown
    public float answerDelayDecrementRate;

    [Header("Selection Choosing")]
    // The current order of sessions
    public List<GameObject> sessionQueue;
    // All possible sessions
    public List<GameObject> sessions;
    // The active dialog session
    public GameObject currentSession;

    /// <summary>
    /// Setup the Love Minigame
    /// </summary>
    void Start()
    {
        // Gather any child Sessions and list them
        // TODO

        // Setup the Sessions Queue
        // TODO

        // Pick our first Session
        // TODO

        // Reset the Score
        lovePointsCurrent = lovePointsStart;
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
