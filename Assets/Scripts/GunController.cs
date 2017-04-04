using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject spherePrefab;
	bool supportsMultiTouch;
	public Transform spawnObject; // object to put on gun that will be @ the tip of it

	public Bounds bounds;


	void Start() {
		supportsMultiTouch = Input.multiTouchEnabled;
	}


	
	// Update is called once per frame
	private void Update () {

		int numTouches = Input.touchCount;
		if (numTouches > 0) {
			for (int x = 0; x < numTouches; x++) {
				Touch touch = Input.GetTouch (x);
				if (touch.phase == TouchPhase.Began) {
					spawnSphere ();
				}
			}
		} else if (Input.GetMouseButtonDown (0)) { // mouse clicked somewhere in unity editor
			spawnSphere ();
		}

		bounds.center = transform.position;

		//Keep the spheres constrained to the screen bounds
//		Vector3 off = Util.ScreenBoundsCheck(bounds,BoundsTest.onScreen);
//		if (off != Vector3.zero) {
//			Destroy (spherePrefab.gameObject);
//		}
	}

	public void spawnSphere() {
		// create object and give it force depending on image tracker on gon position/rotation
		// create game object @ position/rotation of gun
		GameObject go = Instantiate (spherePrefab, spawnObject.position, spawnObject.rotation) as GameObject;
		go.GetComponent<Rigidbody> ().AddForce (transform.forward * 30, ForceMode.VelocityChange);

//		Destroy (go, 5.0f);

//		bounds = Util.CombineBoundsOfChildren (go);
//		Vector3 off = Util.ScreenBoundsCheck(bounds,BoundsTest.onScreen);
//		if (off != Vector3.zero) {
//			Destroy (go);
//		}
	}
}