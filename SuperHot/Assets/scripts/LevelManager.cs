using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(prefab, rooms[i].transform.position + new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }
}
