using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem fire_particle;
    public float ImpactForce = 100f;

    public GameObject ImpactEffect;

    public Camera fpsCam;
	

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            fire_particle.Play();
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.position);

            target Target = hit.transform.GetComponent<target>();
            if (Target != null)
            {
                Target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
            GameObject impact =  Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 0.5f);
        }
    }
}
