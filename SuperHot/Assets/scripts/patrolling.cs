using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolling : MonoBehaviour {

    public Transform[] waypoint;
    NavMeshAgent agent;
    const int epsilon = 2;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoint[4].position);
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position - waypoint[Random.Range(0, waypoint.Length)].position).magnitude < epsilon)
        {
            agent.SetDestination(waypoint[Random.Range(0,waypoint.Length)].position);
        }
	}
}
