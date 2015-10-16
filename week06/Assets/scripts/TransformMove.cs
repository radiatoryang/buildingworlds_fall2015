using UnityEngine;
using System.Collections;

public class TransformMove : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// easiest ways to move something is
		// to just modify the "position" variable
		transform.position += new Vector3(0f, 0.1f, 0f ) * Time.deltaTime;
	
		// Time.deltaTime makes things "FRAMERATE INDEPENDENT"
		// Time.deltaTime = "duration of the frame"
		// e.g. when 10 FPS, dT = 0.1f... when 100FPS, dT = 0.01f

		// if I press SPACE, move forward
		if ( Input.GetKey (KeyCode.Space) ) {
			transform.Translate ( 0f, 0f, 1.5f * Time.deltaTime );
		}
		// left arrow or right arrow should rotate the cube now
		transform.Rotate ( 0f, Input.GetAxis ("Horizontal") * 90f * Time.deltaTime, 0f );
	}
}
