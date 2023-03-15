using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
   
  
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("You Press the Exit Key");
            Application.Quit();
        }
    }
}
