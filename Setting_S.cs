using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting_S : MonoBehaviour
{
    public GameObject SettingsPanel;
    public Dropdown DropDown;
    int flag=0;


    private void Start()
    {
        PlayerPrefs.SetInt("ChoosenInput", GameManager.CarryValue);
        DropDown.value = PlayerPrefs.GetInt("ChoosenInput");
    }



    public void SettingsOpen()
    {
        ++flag;
        if (flag == 1)
        SettingsPanel.SetActive(true);
        else if (flag == 2)
        {
            SettingsPanel.SetActive(false);
            flag = 0;
        }
    }

    public void ControllerChoose(int Value)
    {
        switch (Value)
        {
            case 0:
                GameManager.CarryValue = 0;
                break;
            case 1:
                GameManager.CarryValue = 1;               
                break;
            case 2:
                GameManager.CarryValue = 2;
                break;

        }



    }




}
