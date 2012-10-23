using UnityEngine;
using System.Collections;

public class RotateTheBitch : MonoBehaviour {
	
	public Transform BitchToRotate;
	public float RotationSpeedRPS = 1.0f;
	
	private float fDelayRemaining;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		BitchToRotate.Rotate(0.0f, RotationSpeedRPS * Time.deltaTime, 0.0f);
	}
}
