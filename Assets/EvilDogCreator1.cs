using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilDogCreator1 : MonoBehaviour {

	public GameObject evilDogPrefab;
	public float timeToJump;

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnDog(timeToJump, this.gameObject));
		StartCoroutine(spawnDog(timeToJump+5, this.gameObject));
		StartCoroutine(spawnDog(timeToJump+10, this.gameObject));


	}

	private IEnumerator spawnDog(float seconds, GameObject obj){
		yield return new WaitForSeconds (seconds);
		Instantiate(evilDogPrefab, obj.transform.position, obj.transform.rotation);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
