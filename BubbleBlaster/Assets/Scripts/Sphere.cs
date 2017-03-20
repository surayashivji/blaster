using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

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
		// game object the sphere collided with
		GameObject collidedTarget = collisionInfo.collider.gameObject;
		Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		Debug.Log ("\n");
		Debug.Log (collidedTarget.tag);
		if (collidedTarget.tag == "target_tag" || collidedTarget.tag == "fire_ps") {
			// Destroy target
			Destroy (collisionInfo.collider.gameObject);
			// destroy sphere
			Destroy (this.gameObject);
		} else {
			Debug.Log ("not target tag");
			Debug.Log (collisionInfo.collider.name);
		}
	}
}
