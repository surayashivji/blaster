using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAudioScript : MonoBehaviour {

	// Use this for initialization
	void OnCollisionStay(Collision col)
	{
		GameObject collidedTarget = col.collider.gameObject;
		if (collidedTarget.tag == "sphere") {
			GetComponent<AudioSource> ().volume = 1;
			GetComponent<AudioSource> ().Play ();
			Debug.Log ("Bullet Hitting Target audio played");
		}
	}
}
