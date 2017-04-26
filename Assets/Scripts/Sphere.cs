using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	private TargetLogic targetScript;
	public AudioClip bulletFireSound;
	public AudioClip bulletHitSound;

	void OnBecameInvisible() 
	{
		DestroyObject(gameObject);
	}

	void OnCollisionStay(Collision col)
	{
		GetComponent<AudioSource>().volume = 2;
		GetComponent<AudioSource> ().PlayOneShot (bulletFireSound);
		Debug.Log ("Bullet Fire played");
	}


	void OnCollisionEnter(Collision collisionInfo) 
	{
		// game object the sphere collided with
		GameObject collidedTarget = collisionInfo.collider.gameObject;
		Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		Debug.Log (collidedTarget.tag);
		if (collidedTarget.tag == "target_tag") {

			// Destroy target
			GetComponent<AudioSource>().PlayOneShot(bulletHitSound);
			Destroy (collidedTarget);

			// Destroy particle system on the target if it exists
			Debug.Log("Destroy Particle!");
			collidedTarget.GetComponent<TargetLogic> ().destroyParticle ();
			collidedTarget.GetComponent<TargetLogic> ().AddToScore (50);

			if (!TargetLogic.targetBurning) 
			{
				collidedTarget.GetComponent<TargetLogic> ().AddToScore (30);
			}

			// destroy sphere
			Destroy (this.gameObject);
		} 
		else if (collidedTarget.tag == "Enemy") 
		{

			// Destroy target
			GetComponent<AudioSource>().PlayOneShot(bulletHitSound);
			Destroy (collidedTarget);

			// Destroy particle system on the target if it exists
			collidedTarget.GetComponent<TargetLogic> ().destroyParticle ();

			// destroy sphere
			Destroy (this.gameObject);
		} 
		else 
		{
			Debug.Log (collisionInfo.collider.name);
		}
	}
}