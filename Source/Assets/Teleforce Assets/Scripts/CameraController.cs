using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform tCameraTransform;
	public float fRotationSpeed = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float fPitch = Input.GetAxis("Mouse Y");
		float fRotPitch = fPitch * fRotationSpeed * Time.deltaTime;
		tCameraTransform.Rotate(fRotPitch, 0.0f, 0.0f);
	}
}
