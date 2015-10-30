using UnityEngine;
using System.Collections;

public class SimpleRestart : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// simple Restart button
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ( Application.loadedLevel );
		}
	}
}
