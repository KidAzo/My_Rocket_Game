using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointUp : MonoBehaviour
{
    Vector3 diff;
    Vector3 x;
    public float dist;
    
    void Update()
    {
        x = transform.position;
        diff = transform.position - RocketCall.ChosenX.transform.position;
        if (diff.y <= dist)
        {
            x.y += dist - diff.y;
            transform.position = x;


        }
        else if (diff.y > dist)
        {
            x.y -= diff.y - dist;
            transform.position = x;
        }
    }
}
