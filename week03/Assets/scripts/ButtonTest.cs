using UnityEngine;
using System.Collections;

using UnityEngine.UI; // we need this line to talk to UI

public class ButtonTest : MonoBehaviour {

	int points = 0;
	public Text pointsDisplay; // assign in Inspector

	// a function must be "public void" in order for UI to call it
	public void EarnAPoint () {
		points++; // add 1 to existing value
		pointsDisplay.text = "YOU HAVE: " + points.ToString() + " points!";
	}


}
