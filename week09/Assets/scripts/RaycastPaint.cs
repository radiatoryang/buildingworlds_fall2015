using UnityEngine;
using System.Collections;

public class RaycastPaint : MonoBehaviour {

	public Transform sphere; // assign in Inspector

	// Update is called once per frame
	void Update () {
		// generate a Ray based on my mouse position
		Ray mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
		// for your reference: how to generate a Ray based on what my Camera is looking at
		// Ray lookRay = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
	
		// declare a variable to store RaycastHit data
		RaycastHit mouseRayHit = new RaycastHit();

		if ( Physics.Raycast ( mouseRay, out mouseRayHit, 100f ) ) {
			// sphere.position = mouseRayHit.point;
			// sphere.position = Vector3.Lerp ( sphere.position, mouseRayHit.point - new Vector3(0f, 0f, 0.5f), 0.1f); // "position" of the ray hit
			if (Input.GetMouseButton (0) ) {
				Instantiate ( sphere, mouseRayHit.point, Quaternion.Euler(0f, 0f, 0f) );
			}
		}
	}
}
