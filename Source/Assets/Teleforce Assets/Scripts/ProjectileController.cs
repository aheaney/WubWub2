using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public Transform ShitToPewPew;
	public float Velocity = 1.0f;
	public float Acceleration = 0.1f;
	public float Distance = 5.0f;
	public float Delay = 0.0f;
	//public Renderer RenderController;
	
	private float fDistanceRemaining;
	private float fDelayRemaining;
	private float fCurrentVelocity;
	private Vector3 vDirection;
	//private bool bShot;
	
	// Use this for initialization
	void Start () {
		fDelayRemaining = Delay;
		Reset();
	}
	
	private void Reset()
	{
		fDistanceRemaining = Distance;
		fCurrentVelocity = Velocity;
		ShitToPewPew.position = ShitToPewPew.parent.position;
		vDirection = ShitToPewPew.forward;
		//bShot = false;
		//RenderController.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if (!bShot)
		//{
		//	bShot = Input.GetButtonDown("Fire1");
		//	if (!bShot)
		//	{
		//		return;
		//	}
		//	else
		//	{
		//		RenderController.enabled = true;
		//	}
		//}
		
		if (fDelayRemaining > 0.0f)
		{
			fDelayRemaining -= Time.deltaTime;
			return;
		}
		
		float fDelta = fCurrentVelocity * Time.deltaTime;
		//float fDelta = fDistanceRemaining;
		ShitToPewPew.Translate(vDirection * fDelta, Space.World);
		fDistanceRemaining -= fDelta;
		
		fCurrentVelocity += Acceleration * Time.deltaTime;
		//TTL -= Time.deltaTime;
		
		if (fDistanceRemaining <= 0)// && TTL <= 0)
		{
			Destroy(gameObject);
			//Reset();
		}
	}
}
