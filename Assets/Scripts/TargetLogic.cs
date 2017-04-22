using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetLogic : MonoBehaviour {
	public Text scoreText;

	public int score;

	// time it takes for target to go into fire mode
	public float timeToFireMode = 1.0f;

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
		scoreText = GameObject.Find("Score").GetComponent<Text> ();
		score = 0;
		UpdateScore ();
		targetBurning = false;
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
	}

	void Update()
	{
	}

	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) 
	{
		Debug.Log ("Target is normal, wait for seconds before setting on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log ("set target on fire if it hasn't already been shot at");
		if (obj != null)
		{
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
//			currentFireParticle.transform.SetParent(obj.transform, false);
			StartCoroutine(KillTarget(timeToDeath, obj));
		} 
		else 
		{
			// object has already been killed
			Debug.Log("this target has already been killed no fire needed");
			reclaimPositon (obj);
			yield break;
		}
	}

	private IEnumerator KillTarget(float seconds, GameObject obj) 
	{
		Debug.Log ("We know the target is on fire");
		yield return new WaitForSeconds(seconds);
		if (obj != null) 
		{
			// target has not been shot with sphere
			// destroy target object and particle
			// GAME OVER
			Debug.Log ("target hasn't been killed by sphere yet, so destroy");
			reclaimPositon (obj);
			Destroy (obj);
			Destroy (currentFireParticle);
			SceneManager.LoadScene("GameOver");
		} 
		else if (obj == null) 
		{
			// target has already been destroyed by user
			SceneManager.LoadScene("WinLevel");
			yield break;

		}
	} 

	private void reclaimPositon(GameObject obj) 
	{
		GameObject.FindObjectOfType<SpawnScript> ().ReclaimPosition (obj.transform.position);
	}

	public void destroyParticle() 
	{
			Destroy (this.currentFireParticle);

	}

	public void AddScore()
	{
		score += 100;
		UpdateScore ();
	}

	public void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

}
