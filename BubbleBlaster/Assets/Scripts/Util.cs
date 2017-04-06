using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoundsTest{
	center, //Is the center of the GameObject on screen?
	onScreen, //Are the bounds entirely on screen?
	offScreen, //Are the bounds entirely off screen?
}


public class Util : MonoBehaviour {

	//create bounds that encapsulate the 2 bounds passed in

	public static Bounds BoundsUnion( Bounds b0, Bounds b1){

		// if the size of one of the bounds is Vector3.zero, ignore that one
		if (b0.size == Vector3.zero && b1.size != Vector3.zero) {
				
			return(b1);

		} else if (b0.size != Vector3.zero && b1.size == Vector3.zero) {

			return (b0);

		} else if (b0.size == Vector3.zero && b1.size == Vector3.zero) {

			return(b0);

		}
		//Stretch b0 to include the b1.min and b1.max
		b0.Encapsulate (b1.min);
		//2
		b0.Encapsulate (b1.max);
		return(b0);
	}

	public static Bounds CombineBoundsOfChildren(GameObject go){
		//create an empty Bounds b
		Bounds b = new Bounds(Vector3.zero, Vector3.zero);
		//If this GameObject has a Renderer Component...
		if(go.GetComponent<SpriteRenderer> () != null){
			//Expand b to contain the Renderer's Bounds
			b=BoundsUnion(b,go.GetComponent<SpriteRenderer> ().bounds);
		}
		//If this GameObject has a Collider Component...
		if(go.GetComponent<Collider>() !=null){
			//Expand b to contain the Collider's Bounds
			b=BoundsUnion(b,go.GetComponent<Collider>().bounds);
		}
		//Recursively iterate through each child of this gameObject.transform 
		foreach(Transform t in go.transform){
			//1
			//Expand b to contain their Bounds as well
			b = BoundsUnion(b, CombineBoundsOfChildren(t.gameObject));
			//2
		}

		return(b);

		}

	static public Bounds camBounds {

		get {
			//if cambounds hasn't been set yet
			if (_camBounds.size == Vector3.zero) {
				//set camera bounds using default camera
				SetCameraBounds ();
			}
			return(_camBounds);
		}	
	}


		//private static field that camBounds uses
		static private Bounds _camBounds;
		//this function is used by camBounds to set _camBounds and can also be called directly
		public static void SetCameraBounds(Camera cam=null){
			//if no camera was passed in, use the main camera
			if (cam==null)cam=Camera.main;
			//This makes a couple assumptions about the camera 1. it is orthographic 2. it is at a rotation of R[0,0,0]

			//Make Vector3s at the topLeft and bottomRight of the Screen coords
			Vector3 topLeft = new Vector3(0,0,0);
			Vector3 bottomRight = new Vector3(Screen.width, Screen.height,0);

			//convert these to world coordinates
			Vector3 boundTLN = cam.ScreenToWorldPoint(topLeft);
			Vector3 boundBRF = cam.ScreenToWorldPoint(bottomRight);

			//Adjust their zs to be at the near and far Camera clipping planes
			boundTLN.z += cam.nearClipPlane;
			boundBRF.z += cam.farClipPlane;

			//find the center of the bounds
			Vector3 center = (boundTLN + boundBRF)/2f;

			_camBounds=new Bounds(center,Vector3.zero);

			//expand _camBounds to encapsulate the extents.
			_camBounds.Encapsulate(boundTLN);
			_camBounds.Encapsulate(boundBRF);
		}

	//Checks to see whether the Bounds bnd are within the camBounds
	public static Vector3 ScreenBoundsCheck(Bounds bnd,BoundsTest test= BoundsTest.center){
		return(BoundsInBoundsCheck (camBounds, bnd, test));
	}


	//Checks to see whether Bounds lilB are within Bounds bigB and how far lilB bounds are outisde of camera bounds
	public static Vector3 BoundsInBoundsCheck(Bounds bigB, Bounds lilB, BoundsTest test = BoundsTest.onScreen){
	//The behavior of this function is different based on the BoundsTest that has been selected.
	//Get the center of lilB
		Vector3 pos = lilB.center;

		//initialize the offset at 0,0,0
		Vector3 off = Vector3.zero;

		switch(test){
		//The center test determines what offset would have to be applied to lilB to move its center back inside bigB
		case BoundsTest.center:
			if (bigB.Contains (pos)) {
				return(Vector3.zero);
			}
			if (pos.x > bigB.max.x) {
				off.x = pos.x - bigB.max.x; 
			} else if (pos.x < bigB.min.x) { 
				off.x = pos.x - bigB.min.x; 
			}
			if (pos.y > bigB.max.y) {
				off.y = pos.y - bigB.max.y; 
			} else if (pos.y < bigB.min.y) {
				off.y = pos.y - bigB.min.y; 
			}
			if (pos.z > bigB.max.z) {
				off.z = pos.z - bigB.max.z; 
			} else if (pos.z < bigB.min.z) {
				off.z = pos.z - bigB.min.z;
			}
			return(off);

			//The onScreen test determines what off would have to be applied to keep all of lilB inside bigB
		case BoundsTest.onScreen: 
			if ( bigB.Contains( lilB.min ) && bigB.Contains( lilB.max ) ) {
				return( Vector3. zero ); 
			} if (lilB.max.x > bigB.max.x) { 
			off.x = lilB.max.x - bigB.max.x; 
			} else if (lilB.min.x < bigB.min.x) {
				off.x = lilB.min.x - bigB.min.x; 
			} if (lilB.max.y> bigB.max.y) {
			off.y = lilB.max.y - bigB.max.y; 
			} else if (lilB.min.y < bigB.min.y) {
				off.y = lilB.min.y - bigB.min.y; 
			} if (lilB.max.z > bigB.max.z) { 
			off.z = lilB.max.z - bigB.max.z;
			} else if (lilB.min.z < bigB.min.z) {
				off.z = lilB.min.z - bigB.min.z; 
			} return( off ); 
			// The offScreen test determines what off would need to be applied to  move any tiny part of lilB inside of bigB 
		case BoundsTest.offScreen: 
			bool cMin = bigB.Contains( lilB.min );
			bool cMax = bigB.Contains( lilB.max ); 
			if ( cMin || cMax ) { 
				return( Vector3. zero ); 
			} if (lilB.min.x > bigB.max.x) { 
			off.x = lilB.min.x - bigB.max.x; 
			} else if (lilB.max.x < bigB.min.x) {
				off.x = lilB.max.x - bigB.min.x;
			} if (lilB.min.y > bigB.max.y) { 
			off.y = lilB.min.y - bigB.max.y; 
			} else if (lilB.max.y < bigB.min.y) { 
				off.y = lilB.max.y - bigB.min.y;
			}
		if (lilB.min.z > bigB.max.z) {
		off.z = lilB.min.z - bigB.max.z; 
		} else if (lilB.max.z < bigB.min.z) { 
		off.z = lilB.max.z - bigB.min.z; 
		} return( off ); 
		}
		return( Vector3. zero );
	}
	
	


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
