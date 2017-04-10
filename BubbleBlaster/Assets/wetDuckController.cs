using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wetDuckController : MonoBehaviour {

	public float fallSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Logic for duck to fall after being hit with bubbles
	void Update () {

		transform.Translate (Vector3.down * fallSpeed * Time.deltaTime, Space.World);
		
	}
}
