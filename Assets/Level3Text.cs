using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Text : MonoBehaviour {

	// Use this for initialization
	public float time = 5; //Seconds to read the text

	void Start ()
	{     
		Destroy(gameObject, time);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
