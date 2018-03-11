using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    Transform tr_Player;
    public Transform enemy;
    float f_RotSpeed = 3f;
    float f_MoveSpeed = 2f;
    bool inside = false;
    Animator anim_NPC;
    public Collider Player;
    public GameObject NPC;

    // Use this for initialization
    void Start ()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim_NPC = NPC.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (inside)
        {
            anim_NPC.Play("Running_1", -1);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(tr_Player.position - enemy.transform.position), f_RotSpeed * Time.deltaTime*2);
            enemy.transform.position += enemy.transform.forward * f_MoveSpeed * Time.deltaTime;
            enemy.transform.position = new Vector3(enemy.transform.position.x, 0.1f, enemy.transform.position.z);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
             inside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == Player)
            inside = false;
    }
}

