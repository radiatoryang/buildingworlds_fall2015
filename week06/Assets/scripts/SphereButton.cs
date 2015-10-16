using UnityEngine;
using System.Collections;

public class SphereButton : MonoBehaviour {

	// will happen when user clicks on object with this script
	// the object must have a collider
	void OnMouseUpAsButton () {
		Debug.Log ("You clicked on this!");
		transform.localScale *= 1.1f; // increase by 10% each time I click
	}


}
