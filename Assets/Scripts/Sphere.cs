﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	private TargetLogic targetScript;
	public AudioClip bulletFireSound;
	public AudioClip bulletHitSound;

	void OnBecameInvisible() {
		DestroyObject(gameObject);
	}

	void OnCollisionStay(Collision col)
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource> ().PlayOneShot (bulletFireSound);
		Debug.Log ("Bullet Fire played");
	}


	void OnCollisionEnter(Collision collisionInfo) {
		// game object the sphere collided with
		GameObject collidedTarget = collisionInfo.collider.gameObject;
		Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		Debug.Log (collidedTarget.tag);
		if (collidedTarget.tag == "target_tag") {
			// Destroy target
			GetComponent<AudioSource>().PlayOneShot(bulletHitSound);
			Destroy (collidedTarget);

			// Destroy particle system on the target if it exists
			Debug.Log("DESTROY PARTICLE!");
//			targetScript.destroyParticle ();

			collidedTarget.GetComponent<TargetLogic> ().destroyParticle ();

//			Transform particleTransform = collisionInfo.collider.gameObject.transform.FindChild ("Fire Particle System");
//			GameObject particleObject = particleTransform.gameObject;
//			Destroy (particleObject);

			// destroy sphere
			Destroy (this.gameObject);
		} else {
			Debug.Log (collisionInfo.collider.name);
		}
	}
}