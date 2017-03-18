using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	public static float bottomY = -20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible() {
		DestroyObject(gameObject);
	}

	void OnCollisionEnter(Collision collisionInfo) {
		GameObject collidedTarget = collisionInfo.collider.gameObject;
//		Debug.Log (collisionInfo.collider.name);
		Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
//		DestroyObject (collidedTarget);

	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("HEY \n");
		Debug.Log("Collided with " + other.gameObject.name);
	

	}
}
