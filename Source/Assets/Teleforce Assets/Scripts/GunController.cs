using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public GameObject shot;
    public float fireRate = 0.5F;
	
    private float nextFire = 0.0F;
    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, transform.position, transform.rotation) as GameObject;
			
			// PUT BACK AFTER DEMO!
			//RaycastHit hitInfo;
			//if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 8))
			//{
			//	Object.Destroy(hitInfo.collider.gameObject);
			//}
        }
    }
}
