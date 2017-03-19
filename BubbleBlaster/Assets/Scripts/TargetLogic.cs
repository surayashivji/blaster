using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLogic : MonoBehaviour {

	// time it takes for target to go into fire mode
	public float timeToFireMode = 5.0f;

	// time it takes for target to go from fire mode to destruction
	public float timeToDeath = 10.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SetOnFire(timeToFireMode, this.gameObject));
	}

	private IEnumerator SetOnFire(float seconds, GameObject obj) {
		Debug.Log("Target is normal, wait for seconds: ");
		Debug.Log(seconds);
		yield return new WaitForSeconds(seconds);
		Debug.Log("now set target to the next state and set on fire");
		// set target on fire
		StartCoroutine(KillTarget(timeToDeath, this.gameObject));
	}


	private IEnumerator KillTarget(float seconds, GameObject obj) {
		Debug.Log("Target is ON FIREEE, wait for seconds: ");
		Debug.Log(seconds);
		yield return new WaitForSeconds(seconds);
		Debug.Log ("DESTROY BOBJ");
		Destroy (obj);
	}
}
