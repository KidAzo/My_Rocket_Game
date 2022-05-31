using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketMwithButtonsss : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float angularSpeed;
    [SerializeField]
    float Speed;
    [SerializeField]
    int ReturnS;
    [SerializeField]
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
    GameObject GameManN;
    ButtonControl ButtonControl;
    public static float buttonB;
    void Start()
    {
        GameManN = GameObject.FindGameObjectWithTag("GameManager");
        rb = (Rigidbody)GetComponent("Rigidbody");
        RocketFirst = (RocketFirst)GetComponent("RocketFirst");
        ButtonControl = GameManN.GetComponent<ButtonControl>();
    }

    private void FixedUpdate()
    {
        if (RocketFirst.triggered)
            rb.velocity = RocketFirst.Rocket_force * transform.up * RocketSpeed * Time.deltaTime;


    }
    void Update()
    {   
        RotatonLimit();
        ReturnMiddle();
        


    }


    void RotatonLimit()
    {
       
        buttonB = ButtonControl.ButtonV;
        if (transform.rotation.eulerAngles.magnitude >= LeftSideAngle && A)
        {
            transform.Rotate(0, 0, buttonB * angularSpeed * 2f);//rotationX
            LeftSideAngle = LeftSideAngleKeeper;
            if (transform.rotation.eulerAngles.magnitude < LeftSideAngle)
            {
                A = false;
            }
        }

        if (transform.rotation.eulerAngles.magnitude <= RightSideAngle && A)
        {
            transform.Rotate(0, 0, buttonB * angularSpeed * 2f);//rotationX
            RightSideAngle = RightSideAngleKeeper;
            if (transform.rotation.eulerAngles.magnitude > RightSideAngle - 1)
            {
                A = false;
            }

        }
        if (buttonB > 0 && transform.rotation.eulerAngles.magnitude <= LeftSideAngle + 2)
        {
            A = true;
            LeftSideAngle -= 1;
        }

        if (buttonB < 0 && transform.rotation.eulerAngles.magnitude >= RightSideAngle - 1)
        {
            A = true;
            RightSideAngle = RightSideAngleKeeper + 1;
        }





    }



    void ReturnMiddle()
    {
        if (transform.rotation.eulerAngles.magnitude >= LeftSideAngleKeeper - 2 || transform.rotation.eulerAngles.magnitude <= RightSideAngleKeeper + 2)
        {
            if(!(ButtonControl.RightDown && ButtonControl.LeftDown))
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * ReturnS);
        }

    }

    

}
