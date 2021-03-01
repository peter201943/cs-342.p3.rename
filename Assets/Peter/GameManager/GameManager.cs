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
        // Ensure the GameOver action is hidden
        gameOver.SetActive(false);

        // Ensure the RoundOver action is hidden
        roundOver.SetActive(false);

        roundOverBool = false;
    }

    /// <summary>
    /// Player has failed the game
    /// </summary>
    public void OnGameOver()
    {
        // Show the GameOver action
        gameOver.SetActive(true);
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
        roundOver.SetActive(false);
    }
}
