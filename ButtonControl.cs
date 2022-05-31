using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    public  bool RightDown;
    public  bool LeftDown;
    [SerializeField]
    float IncAm;
    public float ButtonV;

    public void RightDown_T()
    {
        RightDown = true;
    }
    public void LeftDown_T()
    {
        LeftDown = true;
    }
    public void RightUp_T()
    {
        RightDown = false;
        ButtonV = 0;
    }
    public void LeftUp_T()
    {
        LeftDown = false;
        ButtonV = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.Keep_M)
        {
            ButtonV = 0;
            RightDown = false;
            LeftDown = false;
            GameManager.Instance.Keep_M = false;
        }
        ButtonL_R();

    }

    void ButtonL_R()
    {
        if (RightDown)
        {
            if (ButtonV < 1)
                ButtonV += IncAm;
            if (ButtonV > 1)
                ButtonV = 1;
            Debug.Log(ButtonV);

        }
        else if (LeftDown)
        {
            if (ButtonV > -1)
                ButtonV -= IncAm;
            if (ButtonV < -1)
                ButtonV = -1;
            Debug.Log(ButtonV);
        }


    }
}
