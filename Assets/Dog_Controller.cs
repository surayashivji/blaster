using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour {

	public float jumpSpeed;//or whatever you want it to be
	public Rigidbody rb; //and again, whatever you want to call it
	public float timeToJump;


	void Start (){
		rb = GetComponent <Rigidbody>();
		StartCoroutine(dogJump(timeToJump, this.gameObject));

	}

	private IEnumerator dogJump(float seconds, GameObject obj)
	{
		yield return new WaitForSeconds (seconds);
		if (obj != null) {
			
			GetComponent<Animator>().SetBool( "isJumping", true );

		}
	}
			


	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Enemy") {
			GameObject collidedTarget = collisionInfo.collider.gameObject;
			Debug.Log ("Dog hit duck");
			Destroy (collidedTarget);
			Destroy (this.gameObject);
		}

		if (collisionInfo.collider.tag == "sphere") {
			Debug.Log ("sphere hit dog");
			Destroy (this.gameObject);
		}
	}
	void OnBecameInvisible()
	{ 
		Destroy (this.gameObject);
	}


}
