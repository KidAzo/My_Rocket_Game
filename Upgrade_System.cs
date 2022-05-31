using System.Collections.Generic;
using UnityEngine;

public class Upgrade_System : MonoBehaviour
{
    public List<GameObject> Rocketss = new List<GameObject>();
    public RocketChoose RocketChoose;
    RocketKnowledges RocketKnowledges;
    
    private void Update()
    {
        RocketKnowledges = Rocketss[RocketChoose.NowIndex].GetComponent<RocketKnowledges>();
    }
    public void RocketForce_Upgrade()
    {
        RocketKnowledges.Rocket_Force += RocketKnowledges.Rocket_Upgrade;
    }

    public void RocketMovement_Upgrade(int Up_Angle)
    {
        RocketMovement.RightSideAngle += Up_Angle;
        RocketMovement.RightSideAngleKeeper +=Up_Angle;
        RocketMovement.LeftSideAngle -= Up_Angle;
        RocketMovement.LeftSideAngleKeeper -= Up_Angle;
        Debug.Log(RocketMovement.LeftSideAngle);



    }

    /*public void Rocketxadawd_Upgrade()
    {
        RocketKnowledges.Rocket_Force += RocketKnowledges.Rocket_Upgrade;
    }*/


}
