using UnityEngine;
using System.Collections;

// use a Slider to rotate a Cube (admire the cube from all angles)
public class SliderTest : MonoBehaviour {

	public Transform cube;

	// UI functions must be PUBLIC VOID
	public void SetCubeAngle ( float yAngle ) {
		// "OY-ler", 0-360 degree angles
		cube.eulerAngles = new Vector3( 0f, yAngle, 0f );
		// do NOT use "cube.rotation" / "transform.rotation"
	}

}
