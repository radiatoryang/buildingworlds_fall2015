using UnityEngine;
using System.Collections;
using UnityEngine.UI; // if you want to use code to talk to UI objects, you NEED this line here

public class TextTest : MonoBehaviour {

	int numberOfTimesYouPressedSpace = 0;

	// Use this for initialization
	void Start () {
		// is there any "Text" component on the same objects
		GetComponent<Text>().text = "Hola Mundo";
	}
	
	// Update is called once per frame
	void Update () {
		// is the user pressing SPACE on the keyboard, for this frame?
//		if ( Input.GetKey ( KeyCode.Space ) ) {
//			GetComponent<Text>().text = "YOU ARE ENLIGHTENED";
//		} else {
//			GetComponent<Text>().text = "press SPACE for enlightenment";
//		}

		// GetKeyDown requires user to release the key before it'll go again
		if ( Input.GetKeyDown (KeyCode.Space) ) {
			numberOfTimesYouPressedSpace += 1; // add 1 to existing value
			GetComponent<Text>().text = "YOU HAVE PRESSED SPACE: " + numberOfTimesYouPressedSpace.ToString();
		}
	
	}
}
