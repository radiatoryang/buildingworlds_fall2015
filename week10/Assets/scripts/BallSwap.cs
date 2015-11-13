using UnityEngine;
using System.Collections;

public class BallSwap : MonoBehaviour {

	public Transform sphere1, sphere2; // assign in inspector

	// Use this for initialization
	void Start () {
		StartCoroutine ( DemoCoroutine() );
		StartCoroutine ( SwapCoroutine() );
	}

	// a COROUTINE is a type of function where
	// it can last more than 1 frame; we control how fast it runs
	IEnumerator DemoCoroutine () {
		Debug.Log ("coroutine started!");
		yield return 0; // wait for 1 frame... then keep going
		Debug.Log ("1 frame elapsed!");
		yield return 0;
		yield return null; // same as writing "yield return 0"
		Debug.Log ("2 more frames elapsed!");
		yield return new WaitForSeconds(1f); // wait for 1 second
		Debug.Log ("ok I waited for 1 more second.. can we swap now???");
	}


	IEnumerator SwapCoroutine () {
		while ( true ) {
			// remember where the spheres start
			Vector3 sphere1Start = sphere1.position;
			Vector3 sphere2Start = sphere2.position;
			// start swapping positions
			float time = 0f;
			bool didIShakeTheScreenAlready = false;
			while ( time < 1f) {
				time += Time.deltaTime; // add the duration of frame (in seconds)
				sphere1.position = Vector3.Lerp ( sphere1Start, sphere2Start, time );
				sphere2.position = Vector3.Lerp ( sphere2Start, sphere1Start, time );
				if ( time > 0.45f && time < 0.55f && didIShakeTheScreenAlready == false ) {
					StartCoroutine ( ScreenShake () );
					didIShakeTheScreenAlready = true;
					Debug.Log ("shaking the screen!");
				}
				yield return 0; // wait a frame
			}
		}
	}

	IEnumerator ScreenShake () {
		float time = 1f;
		Vector3 cameraStartPos = Camera.main.transform.position;
		while ( time > 0f ) {
			time -= Time.deltaTime / 0.25f; // shake for 0.25 seconds
			Camera.main.transform.position = cameraStartPos +
				new Vector3(0f, Mathf.Sin ( Time.time * 50f ) * time * 0.1f, 0f);
			yield return 0;
		}
		Camera.main.transform.position = cameraStartPos; // reset camera
	}



}
