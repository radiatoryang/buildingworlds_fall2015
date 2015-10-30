using UnityEngine;
using System.Collections;

public class InstantiateDemo : MonoBehaviour {

	public Transform thingToClone; // assign in Inspector
	int cloneCounter = 0; // keep track of how many clones I've cloned
	
	// Update is called once per frame
	void Update () {
		if ( cloneCounter < 1000 ) {
			Vector3 clonePosition = new Vector3(Random.Range (-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f,5f) );
			Transform newClone = (Transform)Instantiate ( thingToClone, 
			                                              clonePosition, 
			                                              Quaternion.Euler(0f, Random.Range(0,360f), 0f)
			            								);
			newClone.localScale = new Vector3(1.62f, 1.62f, 1.62f);

			cloneCounter++;
		}
	}

}
