using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick 2D Cursor-Like thing
/// Uses the A and D or <- and -> keys to move left and right
/// <see href="https://answers.unity.com/questions/1467659/how-to-detect-a-keyboard-key-held-down.html">How to detect a keyboard key held down?</see>
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class LoveGameCursor : MonoBehaviour
{
    // How far left we can travel
    public float leftMax;

    // How far right we can travel
    public float rightMax;

    // Check for Inputs
    private void Update()
    {
        // Move Left
        if ( Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            // TODO Move Cursor
        }

        // Move Right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // TODO Move Cursor
        }
    }
}
