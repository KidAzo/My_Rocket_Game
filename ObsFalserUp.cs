using UnityEngine;

public class ObsFalserUp : MonoBehaviour
{
    Vector3 a, diff;
   


    void Update()
    {
        a = transform.position;
        diff = transform.position - RocketCall.ChosenX.transform.position; //-143-25=-169
        if (diff.y <= -169)
        {
            a.y += - 169 - diff.y;
            transform.position = a;


        }
    }
}
