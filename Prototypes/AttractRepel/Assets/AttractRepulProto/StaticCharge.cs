using UnityEngine;
using System.Collections;

public class StaticCharge : MonoBehaviour {
	
	public float fCharge = 0.0f;
	public bool bEffectedByStatic = false;
	public TextMesh tChargeText;
	
	public static float fK = -1.0f;
	public Rigidbody rCollider;
	
	//public Material mPositiveMat;
	//public Material mNegativeMat;
	//public Material mNeutralMat;
	
	private float fEpsilon = 0.0005f;
	private float fCachedCharge = 0.0f;
	
	private static Color cRed = new Color(0.85f, 0.19f, 0.24f);
	private static Color cBlue = new Color(0.24f, 0.26f, 1.0f);
	private static Color cPurple = new Color(1.0f, 0.27f, 1.0f);
	
	//public Transform t
	
	private float SquaredDistance(Vector3 p1, Vector3 p2)
	{
		float deltaX = p1.x - p2.x;
		float deltaY = p1.y - p2.y;
		float deltaZ = p1.z - p2.z;
		
		return deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ;
	}
	
	private Vector3 CalculateFAttractRepel(Transform tTransformTarget, float fChargeTarget)
	{
		float fSqrDistance = SquaredDistance(rCollider.position, tTransformTarget.position);
		if (Mathf.Abs(fSqrDistance) < fEpsilon)
		{
			return Vector3.zero;
		}
		float fMagnitude = fK * fCharge * fChargeTarget / fSqrDistance;
		Vector3 vDirection = tTransformTarget.position - rCollider.position;
		return vDirection * fMagnitude;
	}
	
	// Use this for initialization
	void Start () {
		if (fCharge > 0.0f)
		{
			renderer.material.color = cRed; //= mPositiveMat;
		}
		else if (fCharge < 0.0f)
		{
			renderer.material.color = cBlue; //= mNegativeMat;
		}
		else
		{
			renderer.material.color = cPurple; //= mNeutralMat;
		}
		
		fCachedCharge = fCharge;
	}
	
	// Update is called once per frame
	void Update () {
		if (bEffectedByStatic)
		{
			GameObject[] aStaticObjects = GameObject.FindGameObjectsWithTag("Charged");
			foreach(GameObject oObject in aStaticObjects)
			{
				StaticCharge chargeScript = oObject.GetComponent<StaticCharge>();
				if (chargeScript != null)
				{
					float fChargeTarget = chargeScript.fCharge;
					Vector3 fNet = CalculateFAttractRepel(oObject.transform, fChargeTarget);
					rCollider.AddForce(fNet);
				}
			}
		}
		
		if (tChargeText != null)
		{
			if (fCharge > 0.0f)
			{
				tChargeText.text = "+ " + fCharge;
			}
			else if (fCharge < 0.0f)
			{
				tChargeText.text = "- " + Mathf.Abs(fCharge);
			}
			else
			{
				tChargeText.text = "neutral";
			}
		}
		
		if (fCharge > 0.0f && !(fCachedCharge > 0.0f))
		{
			renderer.material.color = cRed;
			//rRenderer.materials[0] = mPositiveMat;
		}
		else if (fCharge < 0.0f && !(fCachedCharge < 0.0f))
		{
			renderer.material.color = cBlue;
			//rRenderer.materials[0] = mNegativeMat;
		}
		if (fCharge == 0.0f && fCachedCharge != 0.0f)
		{
			renderer.material.color = cPurple;
			//rRenderer.materials[0] = mNeutralMat;
		}
		
		fCachedCharge = fCharge;
	}
}
