using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used for displaying the player's Love or Money
/// </summary>
public class Bar : MonoBehaviour
{
    // Who we notify on certain events
    public GameManager gameManager;

    // The current stored value
    public int currentValue;

    // The maximum value we can reach
    public int maxValue;

    // The minimum value we can reach
    public int minValue;

    // Text/Effect/Image/Sound we enable when we lose points
    // TODO FUTURE
    // public GameObject loseValue;

    // Text/Effect/Image/Sound we enable when we gain points
    // TODO FUTURE
    // public GameObject addValue;

    void UpdateScore(int amount)
    {
        // Positive Values
        if (amount > 0)
        {
            currentValue = currentValue + amount;
            // TODO FUTURE
            // Trigger any gain related effects
        }

        // Negative Values
        if (amount < 0)
        {
            currentValue = currentValue - amount;
            // TODO FUTURE
            // Trigger any loss related effects
        }

        // Check for Game Over
        if (currentValue < minValue)
        {
            OnEmpty();
            // Reset value to minimum
            currentValue = minValue;
        }

        // Check for On Full
        if (currentValue > maxValue)
        {
            OnFull();
            // Reset value to maximum
            currentValue = maxValue;
        }
    }

    /// <summary>
    /// If we meet our minimum value, tell the game manager we have failed
    /// </summary>
    void OnEmpty()
    {
        gameManager.OnGameOver();
    }

    /// <summary>
    /// Any events we want to have happen when we exceed our maximum
    /// </summary>
    void OnFull()
    {
    }
}
