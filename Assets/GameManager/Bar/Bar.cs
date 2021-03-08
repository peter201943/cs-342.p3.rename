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

    // The Slider used to show our values
    public Slider slider;

    // Text/Effect/Image/Sound we enable when we lose points
    // TODO FUTURE
    // public GameObject loseValue;

    // Text/Effect/Image/Sound we enable when we gain points
    // TODO FUTURE
    // public GameObject addValue;

    /// <summary>
    /// Configures the slider at startup
    /// </summary>
    private void Start()
    {
        slider.maxValue = maxValue;
        slider.minValue = minValue;
        slider.value = currentValue;
    }

    public void UpdateScore(int amount)
    {
        // Positive Values
        if (amount > 0)
        {
            // Update internal value
            currentValue = currentValue + amount;

            // Update displayed value
            slider.value = currentValue;

            // TODO FUTURE
            // Trigger any gain related effects
        }

        // Negative Values
        if (amount < 0)
        {
            // Update internal value
            currentValue = currentValue - amount;

            // Update displayed value
            slider.value = currentValue;

            // TODO FUTURE
            // Trigger any loss related effects
        }

        // Check for Game Over
        if (currentValue < minValue)
        {
            // Reset value to minimum
            currentValue = minValue;

            // Do any effects
            OnEmpty();
        }

        // Check for On Full
        if (currentValue > maxValue)
        {
            // Reset value to maximum
            currentValue = maxValue;

            // Do any effects
            OnFull();
        }
    }

    /// <summary>
    /// If we meet our minimum value, tell the game manager we have failed
    /// </summary>
    private void OnEmpty()
    {
        gameManager.OnGameOver();
    }

    /// <summary>
    /// Any events we want to have happen when we exceed our maximum
    /// </summary>
    private void OnFull()
    {
    }

























    /// <summary>
    /// UTTER hijacking of thisc script
    /// </summary>
    private void Update()
    {
        if ( slider.value < 0.0f )
        {
            gameManager.OnGameOver();
        }
    }





























}
