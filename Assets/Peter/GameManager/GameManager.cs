using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Image/Text/Audio activated on Game Over
    public GameObject gameOver;

    // Image/Text/Audio activated on Round Over
    public GameObject roundOver;

    private bool roundOverBool;

    /// <summary>
    /// Player has started the game
    /// </summary>
    public void Start()
    {
        try
        {
            // Ensure the GameOver action is hidden
            gameOver.SetActive(false);
        }
        catch
        {

        }

        try
        {
            // Ensure the RoundOver action is hidden
            roundOver.SetActive(false);
        }
        catch
        {

        }

        // Update State
        roundOverBool = false;
    }

    /// <summary>
    /// Player has failed the game
    /// </summary>
    public void OnGameOver()
    {
        // Show the GameOver action
        try
        {
            gameOver.SetActive(true);
        }
        catch
        {
        }
    }

    /// <summary>
    /// Player has successfully survived a round
    /// </summary>
    public void RoundOver()
    {
        if (!roundOverBool)
        {
            // Stop Checking
            roundOverBool = true;

            // Show the RoundOver action
            roundOver.SetActive(true);
        }
    }

    /// <summary>
    /// Player has started a new round
    /// </summary>
    public void RoundStart()
    {
        try
        {
            roundOver.SetActive(false);
        }
        catch
        {
        }
    }
}
