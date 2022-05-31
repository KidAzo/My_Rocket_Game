using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RocketFirst : MonoBehaviour
{
    
    [Header("Rocket")]
    public float Rocket_force;
    BoxCollider[] BoxCollider;
    Rigidbody rg;
    [Header("UI")]
    public Text Lifting;
    public Text Score;
    public Text Crashed;
    public Image PowerBar;
    public GameObject PowerBarButton;
    [Header("PowerBar")]
    bool ComeToAnd =false;
    float DelayTime= 0.001f; 
    float PowerBarInc= 0.008f;
    
   
    [Header("Limitation")]
    public float MinxX;
    public float MaxX;
    float LimitedR;
    GameObject GameMan;
    Obstacles Obstacles;
    [Header("Score")]
    public static float Scoree;
    Vector3 FirstY;
    public  bool triggered;
    bool Cstart=true;
  
    void Start()
    {
        GameMan = GameObject.FindGameObjectWithTag("GameManager");
        FirstY = RocketCall.ChosenX.transform.position;
        BoxCollider = GetComponents<BoxCollider>();
        rg = (Rigidbody)GetComponent("Rigidbody"); 
        Obstacles = GameMan.GetComponent<Obstacles>();
   
        Score.enabled = false;      
        Crashed.enabled = false;
        StartCoroutine(PowerBarLoad());
  

       


    }
        
    void Ss()
    {             
            if (Score.enabled && Cstart)
            {               
                Obstacles.StartCoroutine("ObstaclesSpawnn");    
                StartCoroutine("ScoreE");
                Cstart = false;
            }
          
    }
   
    void Update()
    {       
        Limitation();
        Ss();
         
    }
    
    IEnumerator ScoreE()
    {
        while (true)
        {
            Scoree = RocketCall.ChosenX.transform.position.y - FirstY.y;
            Scoree = ((int)Scoree);
            Score.text = Scoree.ToString();
            yield return new WaitForSeconds(.1f);
        }
        

    }
 
    
    IEnumerator PowerBarLoad()
    {
        while (true)
        {
            if (PowerBar.fillAmount < 1 && !ComeToAnd)
            {
                
                PowerBar.fillAmount += PowerBarInc;
                yield return new WaitForSeconds(DelayTime );


            }
            else
            {
                ComeToAnd = true;
                
                PowerBar.fillAmount -= PowerBarInc;
                yield return new WaitForSeconds(DelayTime);
                
                if (PowerBar.fillAmount == 0f)
                         ComeToAnd = false;

            }
        


        }

    }
    
    void Limitation()
    {
        float LimitedP =Mathf.Clamp(transform.position.x, MinxX, MaxX);
        transform.position = new Vector3(LimitedP, transform.position.y, transform.position.z);
        if (transform.position.x == MinxX || transform.position.x == MaxX)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 30);
    }

    public  void PowerRedButton()
    {    
       
        foreach (var item in BoxCollider)
        {
            item.isTrigger = true;
        }
        if (triggered)
        {
            Lifting.enabled = false;
            Score.enabled = true;
            PowerBarButton.SetActive(false);
            if (PowerBar.fillAmount > 0.5f)
            {
                Rocket_force = PowerBar.fillAmount * 60;
                rg.AddForce(0, Rocket_force, 0);
            }
            else
            {
                StartCoroutine("Explosion");
            }
                
        }

    }

    IEnumerator Explosion()
    {
        Rocket_force = PowerBar.fillAmount * 40;
        rg.AddForce(0, Rocket_force, 0);
        yield return new WaitForSeconds(2f);
        Debug.Log("GameOver");
        //ExplosionEffect;
        //GameOverPanel



    }

   
    }






