using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_slow : MonoBehaviour {

    float time_not_moving = 0f;
    bool is_moving = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && Time.timeScale != 0)
            Pause();
        else
        {
            if ( Time.timeScale == 0)
                Time.timeScale = 1;
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
}
