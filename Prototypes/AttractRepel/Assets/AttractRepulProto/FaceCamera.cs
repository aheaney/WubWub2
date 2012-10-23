using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	public Transform tObjectTransform;
	public Transform tCameraTransform;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (cCamera != null)
		//{
			Quaternion qRotation = tCameraTransform.rotation;
			tObjectTransform.rotation = qRotation;
			//tObjectTransform.Rotate(tObjectTransform.up, 2.0f * Mathf.PI);
		//}
	}
}
