using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : LoveGameBehavior
{
    void FixedUpdate()
    {
        subject.transform.Translate(
            0.0f,
             - Time.deltaTime * moveSpeed * (delay + 10f),
            0.0f
        );
    }
}
