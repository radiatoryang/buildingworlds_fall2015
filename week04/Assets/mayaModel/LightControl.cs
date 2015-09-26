using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

	public Light myLight; // assign in Inspector

	// UI functions must be public void
	public void SetLightIntensity ( float intensity ) {
		myLight.intensity = intensity;
	}

}
