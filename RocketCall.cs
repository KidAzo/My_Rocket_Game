using System.Collections.Generic;
using UnityEngine;

public  class RocketCall : MonoBehaviour
{
    public List<GameObject> Rocketcall = new List<GameObject>();
    public int Chosen;
    public static GameObject ChosenX;
    void  Start()
    {
        Chosen = PlayerPrefs.GetInt("ChoosenValue");
        Rocketcall[Chosen].SetActive(true);
        ChosenX = Rocketcall[Chosen];
    }  
}
