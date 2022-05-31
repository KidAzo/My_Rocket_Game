using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public List<GameObject> Obstacles_S =new List<GameObject>();
    public GameObject[] Obstacles_Spawn;
    public  int ObstacleCount=1;
    public  float DelayObs=2.5f;
    public  float DelayObsS =1f;
    public float DelayWhile = 1f;
    float ObsSDelay = 3f;

    private void Start()
    {
        StartCoroutine(ObstaclesSpawnControl());

    }

    IEnumerator ObstaclesSpawnn()
    {
        while (true)
        {           
                    
            for (int i = 0; i < ObstacleCount; i++)
            {
                int Random_Obs = Random.Range(0, Obstacles_S.Count);
                int RandomPoint = Random.Range(0, Obstacles_Spawn.Length);
                if (!Obstacles_S[Random_Obs].activeInHierarchy)
                {
                    Obstacles_S[Random_Obs].transform.position = Obstacles_Spawn[RandomPoint].transform.position;
                    Obstacles_S[Random_Obs].SetActive(true);
                }
                yield return new WaitForSeconds(DelayObsS);
            }
            yield return new WaitForSeconds(DelayWhile);

        }

    }


    IEnumerator ObstaclesSpawnControl()
    {
        while(true)
        {
            if (RocketFirst.Scoree > 2500 && RocketFirst.Scoree < 13000)
            {
                if (ObstacleCount < 8)
                {
                    ++ObstacleCount;
                   
                }
                if (DelayObsS > 0.4f)
                {
                    DelayObsS -= 0.1f;
                   
                }
                if (DelayWhile > 0.4f)
                {
                    DelayWhile -= 0.1f;                 
                }
                yield return new WaitForSeconds(4f);
                continue;
            }
            yield return null;

            Debug.Log("NotToday");
           

        }
        
    }
}

/*IEnumerator ObstaclesSpawnControl()
    {
        while (true)
        {
            if (RocketFirst.Scoree > 2500 && RocketFirst.Scoree < 15000)
            {
                if (ObstacleCount < 7)
                {
                    ++ObstacleCount;
                    Debug.Log(ObstacleCount);
                }
                yield return new WaitForSeconds(3f);
                continue;
            }
            yield return null;

            Debug.Log("NotToday");
           

        }*/