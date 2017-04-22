using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wetDuckController : MonoBehaviour {

	public float fallSpeed;
	public float y;

	// Use this for initialization
	void Start () {
//		y = transform.position.y;
//		InvokeRepeating("fallNow",3f,0.5f); 

	}
	
	// Logic for duck to fall after being hit with bubbles
	void Update () {


	}

	void fallNow()
	{
		y -= 0.4f;
		transform.position = new Vector3(transform.position.x,y,transform.position.z);
	}

}
