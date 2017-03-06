using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject spherePrefab;

	public Transform spawnObject; // object to put on gun that will be @ the tip of it
	
	// Update is called once per frame
	private void Update () {
		// if mouse clicked somewhere
		if (Input.GetMouseButton(0)) {
			// create object and give it force depending on image tracker on gon position/rotation
			// create game object @ position/rotation of gun
			GameObject go = Instantiate (spherePrefab, spawnObject.position, spawnObject.rotation) as GameObject;
			go.GetComponent<Rigidbody> ().AddForce (transform.forward * 30, ForceMode.VelocityChange);
		}
	}
}
