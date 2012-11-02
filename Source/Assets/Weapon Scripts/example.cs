using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    public GameObject shot;
	public GameObject suction;
    public float fireRate = 0.5F;
	public float speed = 20F;
    private float nextFire = 0.0F;
    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, transform.position, transform.rotation) as GameObject;
			clone.rigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
		if (Input.GetButton("Fire2") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(suction, transform.position, transform.rotation) as GameObject;
			clone.rigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
    }
}

