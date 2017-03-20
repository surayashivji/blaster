using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLogic : MonoBehaviour {

	// time it takes for target to go into fire mode
	public float timeToFireMode = 10.0f;

	// time it takes for target to go from fire mode to destruction
	public float timeToDeath = 20.0f;

	// fire particle system
	public GameObject fireParticlePrefab;

	// current fire game object
	private GameObject currentFireParticle;

//
	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) {
		Debug.Log("Target is normal, wait for seconds: ");
		Debug.Log(seconds);
		yield return new WaitForSeconds(seconds);
		Debug.Log("now set target to the next state and set on fire");
		// set target on fire
//		currentFireParticle = Instantiate(fireParticlePrefab, this.gameObject.transform.position, Quaternion.identity);

		currentFireParticle = Instantiate (fireParticlePrefab) as GameObject;
		currentFireParticle.transform.parent = this.gameObject.transform;

		StartCoroutine(KillTarget(timeToDeath, this.gameObject));
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
	}


	private IEnumerator KillTarget(float seconds, GameObject obj) {
		Debug.Log("Target is ON FIREEE, wait for seconds: ");
		Debug.Log(seconds);
		yield return new WaitForSeconds(seconds);
		Debug.Log ("DESTROY BOBJ");
		//Reclaim this target's position for future  spawning
		GameObject.FindObjectOfType<SpawnScript> ().ReclaimPosition (obj.transform.position);
		Destroy (obj);
		Destroy (currentFireParticle);
	}
}
