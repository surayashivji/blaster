using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetLogic : MonoBehaviour {
	// time it takes for target to go into fire mode
	public static float timeToFireMode = 6.0f;

	// time it takes for target to go from fire mode to destruction
	public float timeToDeath = 20.0f;

	// fire particle system
	public GameObject fireParticlePrefab;

	// current fire game object
	private GameObject currentFireParticle;

	// return true if target is burning
	public static bool targetBurning;


	private ScoreManager scoreManager;
	private Timer timer;

	public int count = 5;



	// Use this for initialization
	void Start () {
		targetBurning = false;
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
	}


	void Update() 
	{
		if (timer.myTimer < 1) 
		{
			PrepareForNextLevel ();
			SceneManager.LoadScene("WinLevel");
		}
	}

	/// <summary>
	/// Sets the target on fire by attaching a fire particle system to the game object
	/// @param seconds: number of seconds before setting the target on fire
	/// @param obj: target object to set on fire
	/// </summary>
	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) 
	{
		Debug.Log ("Target is normal, wait for seconds before setting on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log ("set target on fire if it hasn't already been shot at");
		if (obj != null)
		{
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
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

	/// <summary>
	/// Sets the target on fire by attaching a fire particle system to the game object
	/// @param seconds: number of seconds before setting the target on fire
	/// @param obj: target object to set on fire
	/// </summary>
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
			PrepareForNextLevel ();
			SceneManager.LoadScene("GameOver");
		} 
		else if (obj == null) 
		{
			// target has already been destroyed by user
			yield break;

		}
	} 

	/// <summary>
	/// After a target is hit by the user, the position it held is able to be used again
	/// @param obj: game object that was killed with the position we need to recycle back in
	/// </summary>
	private void reclaimPositon(GameObject obj) 
	{
		GameObject.FindObjectOfType<SpawnScript> ().ReclaimPosition (obj.transform.position);
	}

	public void destroyParticle() 
	{
		Destroy (this.currentFireParticle);

	}

	#region SCORE_MANAGER_ACCESSORS

	public void AddToScore(int val)
	{
		scoreManager.UpdateScore (val);
	}

	public void PrepareForNextLevel()
	{
		scoreManager.SaveGameState ();
	}

	#endregion // SCORE_MANAGER_ACCESSORS
}