using UnityEngine;
using System.Collections;

public class ControlStaticCharge : MonoBehaviour {
	
	public StaticCharge ControlledCharge;
	public float Sensitivity = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ControlledCharge != null)
		{
			float fWheel = Input.GetAxis("Mouse ScrollWheel");
			ControlledCharge.fCharge += Mathf.Round(fWheel * Sensitivity);
		}
	}
}
