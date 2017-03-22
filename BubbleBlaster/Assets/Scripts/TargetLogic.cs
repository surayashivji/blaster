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

	// return true if target is burning
	public static bool targetBurning;

	// Use this for initialization
	void Start () {
		targetBurning = false;
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
	}

	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) {
		Debug.Log ("Target is normal, wait for seconds before setting on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log ("set target on fire if it hasn't already been shot at");
		if (obj != null) {
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
//			currentFireParticle.transform.SetParent(obj.transform, false);
			StartCoroutine(KillTarget(timeToDeath, obj));
		} else {
			// object has already been killed
			Debug.Log("this target has already been killed no fire needed");
			reclaimPositon (obj);
			yield break;
		}
	}

	private IEnumerator KillTarget(float seconds, GameObject obj) {
		Debug.Log ("We know the target is on fire");
		yield return new WaitForSeconds(seconds);
		if (obj != null) {
			// target has not been shot with sphere
			// destroy target object and particle
			// GAME OVER
			Debug.Log ("target hasn't been killed by sphere yet, so destroy");
			reclaimPositon (obj);
			Destroy (obj);
			Destroy (currentFireParticle);
		} else {
			// target has already been destroyed by user
			yield break;
		}
	} 

	private void reclaimPositon(GameObject obj) {
		GameObject.FindObjectOfType<SpawnScript> ().ReclaimPosition (obj.transform.position);
	}

	public void destroyParticle() {
		Debug.Log("115");
		Debug.Log("\n");
		Debug.Log("surz");
		if (targetBurning) {
			Destroy (this.currentFireParticle);
		}
	}
}
