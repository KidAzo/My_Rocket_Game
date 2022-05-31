using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketChoose : MonoBehaviour
{
    public List<GameObject> Rockets = new List<GameObject>();
    public int NowIndex =0;
    void Start()
    {
        Rockets[NowIndex].SetActive(true);
    } 

    public void Forward()
    {
        if (NowIndex != 10)
        {
            Rockets[NowIndex++].SetActive(false);  
            Rockets[NowIndex].SetActive(true);

        }
        else
        {
            Rockets[NowIndex].SetActive(false);
            NowIndex = 0;       
            Rockets[NowIndex].SetActive(true);
        }



    }

    public void Back()
    {

        if (NowIndex != 0)
        {
            Rockets[NowIndex--].SetActive(false);
            Rockets[NowIndex].SetActive(true);



        }
        else
        {
            Rockets[NowIndex].SetActive(false);
            NowIndex = 10;         
            Rockets[NowIndex].SetActive(true);
        }
    }

    public void Init()
    {
        PlayerPrefs.SetInt("ChoosenValue", NowIndex);
        SceneManager.LoadScene("MainScene");
    }

}
