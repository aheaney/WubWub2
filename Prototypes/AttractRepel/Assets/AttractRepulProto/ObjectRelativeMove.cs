using UnityEngine;
using System.Collections;

public class ObjectRelativeMove : MonoBehaviour {
	
	public float fSpeed = 10.0f;
	public float fRotationSpeed = 10.0f;
	public float fJumpImpulse = 5000.0f;
	
	public Transform tObjectTransform;
	public Rigidbody rCollider;
	
	private bool bHasJumped;
	
	// Use this for initialization
	void Start () {
		bHasJumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");
		float fYaw = Input.GetAxis("Mouse X");
		bool bJump = Input.GetKeyDown(KeyCode.Space);
		
		Vector3 vDelta = Vector3.forward * yAxis;
		vDelta += Vector3.right * xAxis;
		vDelta *= Time.deltaTime * fSpeed;
		
		tObjectTransform.Translate(vDelta);
		
		float fRotYaw = fYaw * fRotationSpeed * Time.deltaTime;
		tObjectTransform.Rotate(0.0f, fRotYaw, 0.0f);
		
		if (bJump)
		{
			if (!bHasJumped)
			{
				rCollider.AddForce(Vector3.up * fJumpImpulse);
				bHasJumped = true;
			}
		}
		else
		{
			bHasJumped = false;
		}
	}
}
