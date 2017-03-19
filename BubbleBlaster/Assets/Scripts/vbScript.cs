using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler  {

	// create a reference to the vb game object
	private GameObject shootVBObject; 
//	private GameObject gunController;

	// Use this for initialization
	void Start () {

		// initialize gun controller
//		gunController = g/ameObject.GetComponentInParent<GunController>() as GameObject;

		shootVBObject = GameObject.Find ("shootButton");

		// register event handler with virtual button object
		shootVBObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}

	// IVirtualButtonEventHandler interface methods

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		Debug.Log ("BUTTON PRESSED :)");

		// cat.parent.GetComponent<CatController>().ExitConga();

//		gunController.spawnSphere ();
		gameObject.GetComponentInParent<GunController>().spawnSphere();
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}
}
