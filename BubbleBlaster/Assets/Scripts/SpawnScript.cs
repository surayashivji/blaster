using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnScript : MonoBehaviour {

	// red target element to spawn
	public GameObject targetObj;

	// number of targets to spawn
	public int numTargets = 4;

	// time to spawn the targets
	public float timeToSpawn = 1f;

	// hold all targets on stage
	private GameObject[] targetsList;

	// define if position was set
	private bool mPositionSet;

	// Use this for initialization
	void Start () {
		mPositionSet = false;

		// Initialize targets array 
		targetsList = new GameObject[ numTargets ];

		StartCoroutine( SpawnLoop() );
	}

	
	// Update is called once per frame
//	void Update () {
//		
//	}

	// loop Spawning target elements
	private IEnumerator SpawnLoop() {
		// define spawning positon
//		ChangePosition();
		StartCoroutine( ChangePosition() );

		// spawn targets
		int x = 0;
		while (x <= (numTargets - 1)) {
			targetsList [x] = SpawnElement ();
			x++;
			yield return new WaitForSeconds(Random.Range(timeToSpawn, timeToSpawn*2));
		}
	}

	// Spawn a target
	private GameObject SpawnElement() {

//		Vector3 pos = new Vector3(Random.value, Random.value, 10.0f);
//		pos = Camera.main.ViewportToWorldPoint(pos);

//		GameObject target = Instantiate(targetObj, pos, Quaternion.identity);

//		Debug.Log("Object created");


		// spawn the element on a random position inside the device
		GameObject target = Instantiate(targetObj, (Random.insideUnitSphere*4) + transform.position, transform.rotation ) as GameObject;
		// define a random scale for the target
//		float scale = Random.Range(0.05f, 0.1f);
		// change the cube scale
//		target.transform.localScale = new Vector3( scale, scale, scale );
		Debug.Log("Object created");
		return target;
	}

	private void SetPositon() {
		Debug.Log ("seting position \n");
		// get position of AR Camera
		Transform cameraPos = Camera.main.transform;
		Debug.Log(cameraPos);
		// set position 10 units forward from camera's positon
		transform.position = cameraPos.forward * 60;
		Debug.Log ("\n");
		Debug.Log (transform.position);
	}

	private IEnumerator ChangePosition() {
		yield return new WaitForSeconds(0.1f);
		// Define the Spawn position only once
		if ( !mPositionSet ){
			// change the position only if Vuforia is active
			if (VuforiaBehaviour.Instance.enabled)
				Debug.Log ("about to set positon");
				SetPositon();
		}
	}
}