using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantSpawner : MonoBehaviour
{
    public List<GameObject> subjects;
    public float delay = 20f;
    private float currentDelay = 0.0f;
    private int next = 0;

    private void Update()
    {
        currentDelay -= Time.deltaTime;
        if ( currentDelay < delay )
        {
            currentDelay = delay;
            next++;
            if ( next > subjects.Count )
            {
                next = 0;
            }
            Instantiate( subjects[next], transform.position, Quaternion.identity );
        }
    }
}
