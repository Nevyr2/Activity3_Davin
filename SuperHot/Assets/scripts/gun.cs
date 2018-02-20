using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem fire_particle;
    public float ImpactForce = 100f;
    Vector3 random_ball;
    public GameObject first_collider;

    public GameObject ImpactEffect;

    public Camera fpsCam;
	

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            first_collider.GetComponent<BoxCollider>().enabled = false;
            Shoot();
            fire_particle.Play();
            first_collider.GetComponent<BoxCollider>().enabled = true;

        }
	}

    void Shoot()
    {
        RaycastHit hit;

        random_ball.x = fpsCam.transform.position.x - Random.Range(-0.05f, 0.05f);
        random_ball.y = fpsCam.transform.position.y - Random.Range(-0.05f, 0.05f);
        random_ball.z = fpsCam.transform.position.z - Random.Range(-0.05f, 0.05f);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            target Target = hit.transform.GetComponent<target>();
            BoxCollider Target_collider = hit.transform.GetComponent<BoxCollider>();
            if (Target != null && !Target_collider.isTrigger)
            {
                Target.TakeDamage(damage);
                GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 0.5f);
            }
            else
            {

            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

        }
    }
}
