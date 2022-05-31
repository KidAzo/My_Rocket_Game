using UnityEngine;

public class ObsFalser : MonoBehaviour
{
    public GameObject DeathPanel;
 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Falser"))
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Rocket"))
        {
            gameObject.SetActive(false);
            DeathPanel.SetActive(true);
            Time.timeScale = 0;
                            

        }


    }

   




}
