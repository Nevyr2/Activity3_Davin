using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    Transform tr_Player;
    float f_RotSpeed = 3f;
    float f_MoveSpeed = 2f;
    bool inside = false;
       
	// Use this for initialization
	void Start ()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inside)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        inside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }
}
