using UnityEngine;
using System.Collections;

public class RigidbodyMove : MonoBehaviour {

	// make a shortcut for the rigidbody
	Rigidbody rbody;

	Vector3 inputVector; // variable between Update and FixedUpdate
	
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}

	// get user input / keyboard in UPDATE
	void Update () {
		inputVector = new Vector3( Input.GetAxis ("Horizontal"),
		                           0f,
		                           Input.GetAxis ("Vertical" )
		                         );
	}
	
	// FixedUpdate runs every time physics engine runs
	void FixedUpdate () {
		// rbody.velocity = new Vector3(0f, Physics.gravity.y, 5f);
		rbody.velocity = transform.TransformDirection ( inputVector ) * 5f; //+ Physics.gravity * 0.01f;
	}
}
