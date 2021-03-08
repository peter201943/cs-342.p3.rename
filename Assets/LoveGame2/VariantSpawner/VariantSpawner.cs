using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantSpawner : LoveGameBehavior
{
    private float currentDelay = 0.0f;
    private int next = 0;
    public GameObject spawnParent;

    private void Update()
    {
        currentDelay -= Time.deltaTime;
        if ( currentDelay < 0.0f )
        {
            currentDelay = delay;
            next++;
            if ( next > subjects.Count - 1 )
            {
                next = 0;
            }
            GameObject newSubject = Instantiate(
                subjects[next],
                transform.position,
                Quaternion.identity
            );
            newSubject.transform.SetParent(spawnParent.transform);
        }
    }
}
