using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler  {

	// create a reference to the vb game object
	private GameObject shootVBObject;

	// Use this for initialization
	void Start () 
	{
		// initialize gun controller
		shootVBObject = GameObject.Find ("shootButton");

		// register event handler with virtual button object
		shootVBObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}


	#region IVirtualButtonEventHandler Interface Methods

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) 
	{
		Debug.Log ("Virtual Button Pressed");

		gameObject.GetComponentInParent<GunController>().spawnSphere();
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) 
	{
	}

	#endregion
}
