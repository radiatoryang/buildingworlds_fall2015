using UnityEngine;
using System.Collections;

public class StreetMaker : MonoBehaviour {

	//	declare a private var, of type int, called stepCount, starting at 0
	private int stepCount = 0;
	//	declare a public var, of type Transform, called streetMakerPrefab (+ assign in inspector)
	public Transform streetMakerPrefab;
	//	declare a public var, of type Transform, called buildingPrefab (+ assign in inspector)
	public Transform buildingPrefab;
	public Transform building2Prefab;
	public Transform redBuildingPrefab;
	
	// Update is called once per frame
	void Update () {
		//	set [current position] equal to: [current position] + [current forward direction] * 5f
		transform.position = transform.position + transform.forward * 5f;

		//	declare a float called "randomNumber", set it equal to a random float between 0f and 1f
		float randomNumber = Random.Range (0f, 1f);

		//	if "randomNumber" is less than 0.98f, then:
		if ( randomNumber < 0.85f ) {
			//	instantiate a clone of buildingPrefab at [current position + current left direction * 5f] with rotation of [current rotation]
			Transform leftBuilding = (Transform)Instantiate( buildingPrefab, transform.position + -transform.right * 5f, transform.rotation );
			//	set that clone's localScale to (1f, [random number between 1 and 3], 1f)
			leftBuilding.localScale = new Vector3( 1f, Random.Range (1f, 10f), 1f );
			//    instantiate a clone of buildingPrefab at [current position + current right direction * 5f] with rotation of [current rotation]
			Transform rightBuilding = (Transform)Instantiate( buildingPrefab, transform.position + transform.right * 5f, Quaternion.Euler (Random.Range(-30f, 30f), Random.Range (-30f, 30f), Random.Range(-30, 30f) ) );
			//    set that clone's localScale to (1f, [random number between 1 and 3], 1f)
			float height = Random.Range (1f, 10f);
			rightBuilding.localScale = new Vector3( 1f, height, 1f );

		
		
		} else {
			//	declare a float called "anotherRandom", set it equal to a random float between 0f and 1f
			float anotherRandom = Random.value; // Random.value is exactly the same as "Random.Range(0f, 1f)"
			//	if "anotherRandom" is less than 0.5f:...
			if ( anotherRandom < 0.5f ) {
				//	instantiate a clone of streetMakerPrefab at [currentPosition] with [current Y euler rotation + 90 degrees left on Y axis]
				Instantiate ( streetMakerPrefab, transform.position, Quaternion.Euler ( 0f, transform.localEulerAngles.y - 90f, 0f ) );
			} else {
				//	instantiate a clone of streetMakerPrefab at [currentPosition] with [current Y euler rotation + 90 degrees right on Y axis]
				Instantiate ( streetMakerPrefab, transform.position, Quaternion.Euler ( 0f, transform.localEulerAngles.y + 90f, 0f ) );
			}
		}

		//	add 1 to "stepCount"
		stepCount++;
		// declare a var of type Ray called "forwardRay", set it equal to "new Ray( [current position], [current forward direction] )"
		Ray forwardRay = new Ray( transform.position, transform.forward );
		//	if "stepCount" is greater than or equal to 25, OR we raycast 5 units in front of us...
		if ( stepCount >= 15 || Physics.Raycast ( forwardRay, 10f) ) {
			//	then destroy [this gameObject]	
			Destroy ( this.gameObject );
		}

		if (Physics.Raycast ( forwardRay, 5f) ) {
			Debug.Log ("I'm hitting something!");
		}

	}


}
