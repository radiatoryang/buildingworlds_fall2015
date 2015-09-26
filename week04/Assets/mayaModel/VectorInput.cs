using UnityEngine;
using System.Collections;

public class VectorInput : MonoBehaviour {

	// public variables are exposed in Unity's inspector
	public float speed = 1f;

	// Update is called once per frame
	void Update () {
		// go up... GetKey lets me hold down a button
		if ( Input.GetKey (KeyCode.UpArrow) ) {
			transform.position += new Vector3( 0f, speed, 0f) * 10f;
		}

		// go down... GetKeyDown makes me tap repeatedly
		if ( Input.GetKeyDown ( KeyCode.DownArrow ) ) {
			transform.Translate ( 0f, -speed, 0f );
		}

		// rotate the cube based on the horizontal mouse movement ("delta")
		// not moving mouse = 0
		// moving mouse a lot to the right = 1
		// moving mouse a lot to the left = -1
		transform.Rotate ( Input.GetAxis ("Mouse Y"), Input.GetAxis ("Mouse X") * 5f, 0f );


	}
}
