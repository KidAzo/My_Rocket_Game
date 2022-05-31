using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RocketKnowledges : MonoBehaviour
{
    public string Rocket_Name;
    public float Rocket_Force;
    public float Movement;
    public float Health;
    public float Rocket_Upgrade;
    [Header("UI")]
    public TextMeshProUGUI  Rocket_NameE;
    public Slider Rocket_Power;
    public Slider Rocket_Move;
    int slider_percent=6000;
    int slider_Movepercent=100;
    float percent;
    float PercentT;
    void Update()
    {
        Rocket_ForceE();
        Rocket_MoveE();
        Rocket_NameE.text = Rocket_Name;
        transform.Rotate(new Vector3(0, Time.deltaTime * 150, 0));
    }

    void Rocket_ForceE()
    {
        percent = Rocket_Force / slider_percent;

        Rocket_Power.value = percent;



    }
    void Rocket_MoveE()
    {
        PercentT = RocketMovement.RightSideAngle / slider_Movepercent;
        Rocket_Move.value = PercentT;
    }
    public void RocketForce_Upgrade(int Upgrade_Value)
    {
        Rocket_Force += Upgrade_Value;
    }


}
