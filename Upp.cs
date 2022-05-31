using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upp : MonoBehaviour
{
    public GameObject Cam;

    private void Start()
    {
        Vector3 Start_pos = new Vector3(31f, 456f, -77.2f);
        transform.position = Start_pos;
    }
    void Update()
    {
        if (RocketFirst.Scoree >= 340)
        {
            transform.SetParent(Cam.transform);
        }
        
      
    }
}
