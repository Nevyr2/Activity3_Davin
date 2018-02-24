using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {


    int gunDamage = 5;
    public float fireRate = 0.25f;
    public float weaponRange = 100f;
    public float hitForce = 100f;
    public Transform gunEnd;

    public GameObject first_collider;
    public bool dead = false;

    public GameObject ImpactEffect;
    private AudioSource gunAudio;

    public Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;
    private float nextFire;
	


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update ()
    {
    	if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            if (!dead)
            {
                first_collider.GetComponent<BoxCollider>().enabled = false;

	        	nextFire = Time.time + fireRate;

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);

                    target Target = hit.transform.GetComponent<target>();
                    BoxCollider Target_collider = hit.transform.GetComponent<BoxCollider>();
                    if (Target != null && !Target_collider.isTrigger)
                    {
                        Target.TakeDamage(gunDamage);
                        GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impact, 0.5f);
                    }

                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                }

                first_collider.GetComponent<BoxCollider>().enabled = true;
            }
        }
	}

    

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
    	laserLine.enabled = true;
        yield return shotDuration;
	    laserLine.enabled = false;
    }

}
