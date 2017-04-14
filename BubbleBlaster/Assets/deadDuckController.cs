using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadDuckController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
