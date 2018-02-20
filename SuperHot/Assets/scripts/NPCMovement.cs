using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    Transform tr_Player;
    public Transform enemy;
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
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(tr_Player.position - enemy.transform.position), f_RotSpeed * Time.deltaTime);
            enemy.transform.position += enemy.transform.forward * f_MoveSpeed * Time.deltaTime;
            enemy.transform.position = new Vector3(enemy.transform.position.x, 0.1f, enemy.transform.position.z);
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
