using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	void Awake() {
		// avoid creating another copy if user goes back to main menu
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("bg_music");
		if (objects.Length > 1)
			// object running code is second instance of type bg_music, so destroy it
			Destroy (this.gameObject);
		
		// object stays alive throughout
		DontDestroyOnLoad (this.gameObject);
	}
}
