using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadDuckController : MonoBehaviour {

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
