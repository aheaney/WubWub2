using UnityEngine;
using System.Collections;

public class Turntable : MonoBehaviour {
	
	public Transform TransToTurn;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TransToTurn.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
	}
}
