using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Should have a textbox
/// And be configured in Session to be designated right or wrong answer
/// 
/// NOTICE 2021-03-07
/// Major change to how this is handled
/// Answers will now fall down and need to be navigated to
/// They are triggered by collisions
/// <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html">MonoBehaviour.OnCollisionEnter2D(Collision2D)</see>
/// </summary>
public class Answer : MonoBehaviour
{

    // who we notify on mouse click
    public Session session;

    /// <summary>
    /// When user hits us (if at all)
    /// </summary>
    void OnCollisionEnter2D(Collision2D col)
    {
        // TODO FUTURE
        // Play any effects

        // TEMP DEBUG
        Debug.Log("Was Collided");

        // Notify the session with ourselves
        session.Answer(this.gameObject);
    }


    /// <summary>
    /// Causes us to fall down
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        gameObject.transform.Translate(moveHorizontal * 0.05f, moveVertical * 0.25f, 0.0f);
    }

}
