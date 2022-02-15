using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour {

	public Vector3 angle;
	
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( angle * Time.deltaTime);
	}
}
