using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

	private void OnCollisionStay(Collision col)
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().Play ();
	}

}
