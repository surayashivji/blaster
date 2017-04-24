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

	/// <summary>
	/// Fired when the Virtual Button is pressed on the AR marker
	/// @param vb: behavior received from virtual button
	/// </summary>
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) 
	{
		gameObject.GetComponentInParent<GunController>().spawnSphere();
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) 
	{
	}

	#endregion
}
