using UnityEngine;


public class CameraFollow : MonoBehaviour
{
   
    GameObject targetToFollow;
    void Update()
    {
        targetToFollow = RocketCall.ChosenX;
        transform.position = new Vector3(transform.position.x, targetToFollow.transform.position.y+80, transform.position.z);
        }
  
}
