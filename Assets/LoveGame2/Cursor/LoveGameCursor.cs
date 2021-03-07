using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick 2D Cursor-Like thing
/// Uses the A and D or <- and -> keys to move left and right
/// <see href="https://answers.unity.com/questions/1467659/how-to-detect-a-keyboard-key-held-down.html">How to detect a keyboard key held down?</see>
/// <see href="https://gamedev.stackexchange.com/questions/152516/what-is-the-script-that-is-needed-to-move-a-2d-spritesquare">what is the script that is needed to move a 2D sprite(square)?</see>
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class LoveGameCursor : MonoBehaviour
{
    // How far left we can travel
    public Transform leftMax;

    // How far right we can travel
    public Transform rightMax;

    // How fast we can travel
    public float moveSpeed = 400;

    // Move Directions
    private Vector3 leftward  = new Vector3(-1,  0,  0);
    private Vector3 rightward = new Vector3( 1,  0,  0);


    // Check for Inputs
    private void Update()
    {
        // Move Left
        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
            // Do not proceed outside bounds
            if ( leftMax.position.x < transform.position.x )
            {
                // TEMP DEBUG
                Debug.Log("Moving Left");

                // Move Cursor Left
                transform.Translate(leftward * moveSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                // TEMP DEBUG
                Debug.Log("Cannot move Left");
            }
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Do not proceed outside bounds
            if ( transform.position.x < rightMax.position.x )
            {
                // TEMP DEBUG
                Debug.Log("Moving Right");

                // Move Cursor Right
                transform.Translate(rightward * moveSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                // TEMP DEBUG
                Debug.Log("Cannot move Right");
            }
        }
    }
}
