using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void OnEnable()
    {
        
        _instance = this;
    }

    public GameObject DeathPanel;
    RocketFirst RocketFirstt;
    Obstacles Obstacles;
    GameObject ChooseN;
    public static int CarryValue;
    public GameObject[] InputPanels;
    GameObject Rocket;

    public bool Keep_M;
    

    void Start()
    {
        ChooseN=RocketCall.ChosenX;
        RocketFirstt = ChooseN.GetComponent<RocketFirst>();
        Obstacles = (Obstacles)GetComponent("Obstacles");
        SettingsValue();

    }

    private void Update()
    {
        FalseInputs();
    }
    public void PlayAgain()
    {
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PowerBarR()
    {
       
        RocketFirstt.triggered = true;
        RocketFirstt.PowerRedButton();
       
    }
    public void KeepMoving()
    {
        DeathPanel.SetActive(false);
        Rocket = RocketCall.ChosenX;
        
        for (int i = 0; i < Obstacles.Obstacles_S.Count; i++)
        {
            Obstacles.Obstacles_S[i].SetActive(false);
        }
        Keep_M = true;
        
        Time.timeScale = 1;
         

    }

    void SettingsValue()
    {
        if (CarryValue == 0)
        {
            RocketCall.ChosenX.GetComponent<RocketMovement>().enabled = true;
            RocketCall.ChosenX.GetComponent<RocketMwithButtonsss>().enabled = false;
        }
        if (CarryValue == 1 || CarryValue == 2)
        {
            RocketCall.ChosenX.GetComponent<RocketMovement>().enabled = false;
            RocketCall.ChosenX.GetComponent<RocketMwithButtonsss>().enabled = true;
        }

    }

    void FalseInputs()
    {
        if (DeathPanel.activeInHierarchy)
        {
            for (int i = 0; i < InputPanels.Length; i++)
            {
                InputPanels[i].SetActive(false);
            }
        }

        else
        {
            for (int i = 0; i < InputPanels.Length; i++)            
                    InputPanels[i].SetActive(false);          
            
            if (RocketFirstt.triggered)
                InputPanels[CarryValue].SetActive(true);
        }

    }
}
