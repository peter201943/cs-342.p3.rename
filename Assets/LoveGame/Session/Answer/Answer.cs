using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Should have a textbox
/// And be configured in Session to be designated right or wrong answer
/// </summary>
public class Answer : MonoBehaviour
{

    // who we notify on mouse click
    public Session session;

    /// <summary>
    /// When user clicks on us
    /// </summary>
    private void OnMouseDown()
    {
        // TODO FUTURE
        // Play any effects

        // Notify the session with ourselves
        session.Answer(this.gameObject);
    }

}
