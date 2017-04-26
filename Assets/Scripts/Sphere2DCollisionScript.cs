using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere2DCollisionScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{ 
			Debug.Log ("Bullet hit 2d Duck");
			Destroy (other.gameObject);
		}
	}


}
