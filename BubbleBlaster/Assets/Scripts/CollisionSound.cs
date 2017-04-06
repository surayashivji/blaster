using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {


	//Volume: 0-1
	//Magnitude: 

	void OnCollisionStay(Collision col)
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().Play ();
		Debug.Log ("Audio played");
	}

}
