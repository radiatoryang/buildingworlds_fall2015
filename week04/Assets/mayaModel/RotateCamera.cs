using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	public Transform pivot;
	public Transform rotateThing;


	// Update is called once per frame
	void Update () {
		// rotateThing.RotateAround ( pivot.position, Vector3.up, 5f );
	}

	public void SliderRotate( float newRotation ) {
		float difference = rotateThing.localEulerAngles.y - newRotation;
		rotateThing.RotateAround ( pivot.position, Vector3.up, difference );
	}
}
