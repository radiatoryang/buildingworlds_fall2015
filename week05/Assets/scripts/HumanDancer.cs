using UnityEngine;
using System.Collections;

public class HumanDancer : MonoBehaviour {
	// human controlled dancer pseudocode
	// suggested workflow: paste this into a C# script, translate line by line

	// outside Update, declare a Vector3 called "targetPosition", initialized at (0,0,0)
	Vector3 targetPosition = Vector3.zero;

	// Update is called once per frame
	void Update () {
		// DETECT HORIZONTAL MOUSE MOVEMENT
		// declare a float "targetX", initialize to targetPosition's X
		float targetX = targetPosition.x;
		// add [current mouse X axis value] to existing targetX
		targetX += Input.GetAxis ( "Mouse X" );
		// clamp targetX between -5f and 5f using Mathf.Clamp() (google how to use it)
		targetX = Mathf.Clamp ( targetX, -5f, 5f);


		// DETECT VERTICAL MOUSE MOVEMENT
		// declare a float "targetZ", initialize to targetPosition's Z
		float targetZ = targetPosition.z;
		// add [current mouse Y axis value] to existing targetZ
		targetZ += Input.GetAxis("Mouse Y");
		// clamp targetZ between -5f and 5f using Mathf.Clamp() (google how to use it)
		targetZ = Mathf.Clamp ( targetZ, -5f, 5f);

		// ACTUALLY MOVE THE OBJECT NOW
		// set targetPosition equal to (targetX, 0, targetZ)
		targetPosition = new Vector3( targetX, 0f, targetZ );
		// move current transform's position 10% of the way towards targetPosition
		transform.position += ( targetPosition - transform.position) * 0.1f;
		// HINT: the formula looks like: [position] += ([destination] - [position])*0.1f;  
		// HINT: fill-in [position] and [destination] with your own variables... what are they?
		
		// TEST YOUR SCRIPT TO MAKE SURE IT WORKS
		// when it works, tune it and personalize it:
		// - make the movement framerate-independent?
		// - halve the mouse sensitivity?
		// - double the allowed movement range?
		// - make it move twice as fast?
	}
}
