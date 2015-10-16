using UnityEngine;
using System.Collections;

public class RaycastDemo : MonoBehaviour {

	public Transform sphere; // this transform will follow the cursor

	Transform thingGrabbed; // this transform we can "drag and drop"
	public Transform ignoreThisWall;

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
		RaycastHit rayHit = new RaycastHit(); // blank var to remember where it hits

		if ( Physics.Raycast ( ray, out rayHit, 1000f ) ) {
			Debug.DrawRay ( ray.origin, ray.direction * 1000f, Color.yellow );
			// rayHit.point = WHERE, rayHit.normal = SURFACE DIRECTION
			Debug.DrawRay ( rayHit.point, rayHit.normal, Color.red );

			// sphere to go from A to B, so I use the formula B-A
			sphere.position += (rayHit.point - sphere.position) * 0.1f;


			// "Drag and Drop" ================================
			if (Input.GetMouseButtonDown( 0 ) && rayHit.transform != ignoreThisWall ) {
				thingGrabbed = rayHit.transform; // remember the thing we clicked on
				thingGrabbed.GetComponent<Collider>().enabled = false;
			}

			// move the thing to where your cursor is
			if (thingGrabbed != null) { // only do all this if we're grabbing a thing
				thingGrabbed.position = rayHit.point;

				if ( Input.GetMouseButton( 0 ) == false ) {
					thingGrabbed.GetComponent<Collider>().enabled = true;
					thingGrabbed = null;
				}
			}

		}



	}

}
