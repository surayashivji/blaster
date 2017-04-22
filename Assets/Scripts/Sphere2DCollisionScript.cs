using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere2DCollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{ 
			Debug.Log ("Bullet hit 2d Duck");
			Destroy (other.gameObject);
		}
	}


}
