using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_slow : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update ()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && Time.timeScale == 0)
            Time.timeScale = 1;
        else
        {
            if ( Time.timeScale == 1)
                Time.timeScale = 0;
        }
    }

    

}
