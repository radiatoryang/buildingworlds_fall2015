using UnityEngine;
using System.Collections;

public class SphereButton : MonoBehaviour {

	// detects whether the user left-clicked on the collider,
	// then released left-mouse-button with cursor STILL over collider
	void OnMouseUpAsButton () {
		// make sphere grow when I click on it
		transform.localScale *= 1.1f;

		// the line above is EXACTLY like writing the line below:
		// transform.localScale = transform.localScale * 1.1f;
	}

}
