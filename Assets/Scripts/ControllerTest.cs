using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour
{
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
            Debug.Log("horizontal: " + h.ToString("f2") + " vertical: " + v.ToString("f2"));
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 19; j++)
            {
                if(Input.GetKeyDown("joystick " + i.ToString() + " button " + j.ToString()))
                {
                    Debug.Log("joystick " + i.ToString() + " button " + j.ToString());
                }
                                       
            }
        }
    }
}
