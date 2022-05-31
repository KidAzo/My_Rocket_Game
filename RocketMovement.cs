using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    public VariableJoystick Joystick;

    [SerializeField]
    float angularSpeed;
    [SerializeField]
    float Speed;
    [SerializeField]
    int ReturnS;

    public float RocketSpeed;
    float rotationX;
    public static float rotationY;
    RocketFirst RocketFirst;
  
    bool CamA = true;
    bool CamAA = true;
    Animator Animator;
    Vector3 a;
    bool A = true;
    public static float LeftSideAngle = 330;
    public static float LeftSideAngleKeeper = 330;
    public static float RightSideAngle = 30;
    public static float RightSideAngleKeeper = 30;

   
    
    void Start()
    {

        rb = (Rigidbody)GetComponent("Rigidbody");
        RocketFirst = (RocketFirst)GetComponent("RocketFirst");

    }

    private void FixedUpdate()
    {
        if (RocketFirst.triggered)           
            rb.velocity = RocketFirst.Rocket_force * transform.up * RocketSpeed * Time.deltaTime;


    }
    void LateUpdate()
    {
        RotatonLimit();
        ReturnMiddle();
       
      
    }

    
    void RotatonLimit()
    {
      
        rotationX = Joystick.Horizontal;
        if (transform.rotation.eulerAngles.magnitude >= LeftSideAngle && A)
        {
            transform.Rotate(0, 0, rotationX * angularSpeed * 2f);//rotationX
            LeftSideAngle = LeftSideAngleKeeper;
             if (transform.rotation.eulerAngles.magnitude < LeftSideAngle)
            {
                A = false;
            }
        }

        if (transform.rotation.eulerAngles.magnitude <= RightSideAngle && A)
        {
            transform.Rotate(0, 0, rotationX * angularSpeed * 2f);//rotationX
            RightSideAngle = RightSideAngleKeeper;
            if (transform.rotation.eulerAngles.magnitude > RightSideAngle - 1)
            {
                A = false;
            }

        }
        if (rotationX > 0 && transform.rotation.eulerAngles.magnitude <= LeftSideAngle + 2)
        {
            A = true;
            LeftSideAngle -= 1;
        }

        if (rotationX < 0 && transform.rotation.eulerAngles.magnitude >= RightSideAngle - 1)
        {
            A = true;
            RightSideAngle = RightSideAngleKeeper + 1;
        }





    }



    void ReturnMiddle()
    {
        if (transform.rotation.eulerAngles.magnitude >= LeftSideAngleKeeper -2 || transform.rotation.eulerAngles.magnitude <= RightSideAngleKeeper +2)
        {
            if (Joystick.Horizontal == 0)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * ReturnS);
        }

    }


}



