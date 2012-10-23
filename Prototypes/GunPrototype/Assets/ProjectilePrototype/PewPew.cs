using UnityEngine;
using System.Collections;

public class PewPew : MonoBehaviour {
	
	public Transform ShitToPewPew;
	public float Velocity = 1.0f;
	public float Acceleration = 0.1f;
	public float Distance = 5.0f;
	public float Delay = 0.0f;
	
	private float fDistanceRemaining;
	private Vector3 vInitialPos;
	private float fDelayRemaining;
	private float fCurrentVelocity;
	
	// Use this for initialization
	void Start () {
		fDelayRemaining = Delay;
		vInitialPos = ShitToPewPew.position;
	}
	
	private void Reset()
	{
		fDistanceRemaining = Distance;
		fCurrentVelocity = Velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (fDelayRemaining > 0.0f)
		{
			fDelayRemaining -= Time.deltaTime;
			return;
		}
		
		float fDelta = fCurrentVelocity * Time.deltaTime;
		ShitToPewPew.Translate(0.0f, fDelta, 0.0f);
		fDistanceRemaining -= fDelta;
		
		fCurrentVelocity += Acceleration * Time.deltaTime;
		
		if (fDistanceRemaining <= 0)
		{
			ShitToPewPew.position = vInitialPos;
			Reset();
		}
	}
}
