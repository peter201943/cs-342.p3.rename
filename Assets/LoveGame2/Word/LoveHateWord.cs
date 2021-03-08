using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotion
{
    Love,
    Hate
};

public class LoveHateWord : LoveGameBehavior
{
    public Emotion emotion = Emotion.Love;
    public float lifetime = 5.0f;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if ( lifetime < 0.0f )
        {
            Debug.Log("Auf");
            Destroy(gameObject);
        }

        // EMERGENCY DEBUG - Unity is not updating the values
        // ABSOLUTE HACK WARN
        if ( lifetime > 5.0f )
        {
            lifetime = 5.0f;
        }
    }
}
